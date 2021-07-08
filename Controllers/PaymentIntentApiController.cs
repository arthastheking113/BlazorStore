using BlazorStore.Data;
using BlazorStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stripe.Checkout;
using Microsoft.EntityFrameworkCore;
using BlazorStore.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.Encodings.Web;

namespace BlazorStore.Controllers
{
    [Route("create-checkout-session")]
    [ApiController]
    public class PaymentIntentApiController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CustomUser> _userManger;
        private readonly ICanUserComment _canUserComment;
        private readonly IEmailSender _emailSender;

        public PaymentIntentApiController(ApplicationDbContext context,
            UserManager<CustomUser> userManger,
             ICanUserComment canUserComment,
              IEmailSender emailSender)
        {
            _context = context;
            _userManger = userManger;
            _canUserComment = canUserComment;
            _emailSender = emailSender;
        }
        [HttpPost]
        public async Task<ActionResult> CreateAsync()
        {
            string host = "https://" + HttpContext.Request.Host.ToString() + "/";
            var CartList = await _context.Cart.Where(i => i.CustomUserId == _userManger.GetUserId(User) && !i.IsSold).Include(i => i.Category).Include(i => i.CustomUser).ToListAsync();
            foreach (var items in CartList)
            {
                var saleOffId = _context.Item.FirstOrDefault(i => i.Id == items.ItemId).ItemSaleOffId;
                var price = _context.Item.FirstOrDefault(i => i.Id == items.ItemId).Price;
                var CurrentPrice = _context.Item.FirstOrDefault(i => i.Id == items.ItemId).ListPrice(_context, price, saleOffId);
                if (items.Price != CurrentPrice)
                {
                    items.Price = CurrentPrice;
                    _context.Update(items);
                    await _context.SaveChangesAsync();
                }
            }

            decimal total = 0;
            decimal TotalItem = 0;
            foreach (var items in CartList)
            {
                total += (Convert.ToDecimal(items.Price) * (decimal)items.Quantity);
                TotalItem += (decimal)items.Quantity;
            }

            total += (decimal)20;
            decimal faxFee = total * (decimal)7 / (decimal)100;
            decimal TotalGrand = total + faxFee;
            TotalGrand = TotalGrand * 100;
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                  "card",
                },
                LineItems = new List<SessionLineItemOptions>
                {
                  new SessionLineItemOptions
                  {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                      UnitAmount = (long)TotalGrand,
                      Currency = "usd",
                      ProductData = new SessionLineItemPriceDataProductDataOptions
                      {
                        Name = "Lan's market",
                      },
                    },
                    Quantity = 1,
                  },
                },
                Mode = "payment",
                SuccessUrl = host + "process",
                CancelUrl = host + "cart",
            };
            var service = new SessionService();
            Session session = service.Create(options);
            return Json(new { id = session.Id });
        }
        public async Task<IActionResult> ProcessAsync()
        {
            var applicationDbContext = await _context.Orders.Include(o => o.Category)
               .Include(o => o.CustomUser)
               .Include(o => o.OrderStatus)
               .Include(o => o.Item)
               .OrderByDescending(o => o.Updated).ToListAsync();
            List<Order> orderList = new List<Order>();
            foreach (var item in applicationDbContext)
            {
                var trackingNumber = item.TrackingNumber;
                if (!orderList.Select(o => o.TrackingNumber).Contains(trackingNumber))
                {
                    orderList.Add(item);
                }
            }

            await DeleteOrder180DayAgoAsync();

            var TrackingNumber = CreateTrackingNumber();

            var CartList = await _context.Cart.Where(i => i.CustomUserId == _userManger.GetUserId(User) && !i.IsSold)
                .Include(i => i.Category)
                .Include(i => i.CustomUser)
                .ToListAsync();

            var ReceivedStatus = _context.OrderStatuses.FirstOrDefault(o => o.Name == "Received").Id;
            var user = await _userManger.FindByIdAsync(CartList.First().CustomUserId);
            var currentTime = DateTimeOffset.Now;
            foreach (var items in CartList)
            {


                //update number of sold item
                var item_of_shop = _context.Item.FirstOrDefault(i => i.Id == items.ItemId);
                item_of_shop.Number_Of_Sold += 1;
                await _canUserComment.AddUserToItemAsync(user.Id, items.ItemId);
                _context.Update(item_of_shop);
                await _context.SaveChangesAsync();

                Order newOrder = new Order
                {
                    TrackingNumber = TrackingNumber,
                    Name = items.Name,
                    Price = items.Price,
                    CustomUserId = items.CustomUserId,
                    CategoryId = items.CategoryId,
                    ItemId = items.ItemId,
                    Quantity = items.Quantity,
                    IsSold = true,
                    ImageData = items.ImageData,
                    ContentType = items.ContentType,
                    Date = currentTime,
                    Notes = items.Notes,
                    Slug = items.Slug,
                    IsViewByOwner = false,
                    OrderStatusId = ReceivedStatus,
                    TrackingLink = "We are currently working on tracking link!",
                    Created = currentTime,
                    Updated = currentTime,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    Adress = user.Street,
                    State = user.State,
                    City = user.City,
                    Zipcode = user.Zipcode
                };
                _context.Add(newOrder);
                await _context.SaveChangesAsync();

                _context.Cart.Remove(items);
                await _context.SaveChangesAsync();
            }


            var callbackUrl = Url.Action(
                                    "TrackOrderDetails",
                                    "Orders",
                                    values: new { TrackingNumber = TrackingNumber },
                                    protocol: Request.Scheme);

            await _emailSender.SendEmailAsync(user.Email, "Lan's Market received your order",
                $"<h1>You successfully placed an order on Lan's Market at {(currentTime).ToString("dd MMMM yyyy - hh:mm tt")}</h1> <br> <a style='background-color: #555555;border: none;color: white;padding: 15px 32px;text-align: center;text-decoration: none;display: inline-block;font-size: 16px;' href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Clicking here to track your order</a>  <br> <h3>Your Tracking Number is: {TrackingNumber} </h3> <br>");


            await _emailSender.SendEmailAsync("arthastheking113@gmail.com", "New order has been placed at Lan's Market",
               $"<h1>A new order have been placed at {(currentTime).ToString("dd MMMM yyyy - hh:mm tt")}</h1> <br> <a style='background-color: #555555;border: none;color: white;padding: 15px 32px;text-align: center;text-decoration: none;display: inline-block;font-size: 16px;' href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Clicking here to go to order</a>  <br> <h3>Tracking Number is: {TrackingNumber} </h3> <br>");


            ViewData["TrackingNumber"] = TrackingNumber;
            var tracking = TrackingNumber.ToString();
            return RedirectToAction("Success", "PaymentIntentApi", new { tracking });
        }
        public IActionResult Success(string trackingNumber)
        {
            ViewData["TrackingNumber"] = trackingNumber;
            return View();
        }


        public async Task DeleteOrder180DayAgoAsync()
        {
            var currentTime = DateTimeOffset.Now;
            var StatusFinish = _context.OrderStatuses.FirstOrDefault(o => o.Name == "Finish").Id;
            var Order_Complete = await _context.Orders.Where(t => t.Updated >= currentTime.AddDays(-180) && t.OrderStatusId == StatusFinish).ToListAsync();
            foreach (var item2 in Order_Complete)
            {
                _context.Orders.Remove(item2);
            }
            await _context.SaveChangesAsync();
        }

        public string CreateTrackingNumber()
        {
            Random rand = new Random();
            var RandomNumber = Enumerable.Range(0, 10)
                                         .Select(i => new Tuple<int, int>(rand.Next(10), i))
                                         .OrderBy(i => i.Item1)
                                         .Select(i => i.Item2);
            var TrackingNumber = String.Join("", string.Join(";", RandomNumber).Split('@', ',', '.', ';', '\''));


            while (_context.Orders.Where(i => i.TrackingNumber == TrackingNumber).ToList().Count > 0)
            {
                RandomNumber = Enumerable.Range(0, 10)
                                         .Select(i => new Tuple<int, int>(rand.Next(10), i))
                                         .OrderBy(i => i.Item1)
                                         .Select(i => i.Item2);
                TrackingNumber = String.Join("", string.Join(";", RandomNumber).Split('@', ',', '.', ';', '\''));
            }
            return TrackingNumber;
        }
    }
}
