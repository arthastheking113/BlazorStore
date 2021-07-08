using BlazorStore.Data;
using BlazorStore.Models;
using BlazorStore.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Ultilities
{
    public class DataManage
    {

        public static string GetConnectionString(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
        }
        public static string BuildConnectionString(string databaseUrl)
        {
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(":");

            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Prefer,
                TrustServerCertificate = true
            };
            return builder.ToString();
        }

        public static async Task ManageDataAsync(IHost host)
        {
            using var svcScope = host.Services.CreateScope();
            var svcProvider = svcScope.ServiceProvider;

            var dbContextSvc = svcProvider.GetRequiredService<ApplicationDbContext>();
            // an instance of role manager
            var roleManagerSvc = svcProvider.GetRequiredService<RoleManager<IdentityRole>>();
            // an instance of usermanager
            var userManageSvc = svcProvider.GetRequiredService<UserManager<CustomUser>>();
            // an instance of slug service
            var slugService = svcProvider.GetRequiredService<ISlugService>();

            await dbContextSvc.Database.MigrateAsync();
            //await dbContextSvc.Database.MigrateAsync();

            //add attachment Type to the system
            await SeedAttachmentType(dbContextSvc);
            //add order status to the system
            await SeedOrderStatusAsync(dbContextSvc);
            //add rate to the system
            await SeedRateAsync(dbContextSvc);
            //add category to the system
            await SeedCategoryAsync(dbContextSvc, slugService);
            //add ItemSaleOff to the system
            await SeedItemSaleOffAsync(dbContextSvc);
            //add ItemStatus to the system
            await SeedItemStatusAsync(dbContextSvc);
            //add Item to the system
            await SeedItemAsync(dbContextSvc, slugService);
            // add role to the system
            await SeedRoleAsync(roleManagerSvc);
            //add user
            await SeedUserAsync(userManageSvc);
            // assign role
            await AssignRoleAsync(userManageSvc);

        }
        public static async Task SeedAttachmentType(ApplicationDbContext _context)
        {
            if (_context.ItemAttachmentTypes.Count() == 0)
            {
                ItemAttachmentType InSide = new ItemAttachmentType
                {
                    Name = "InSide"
                };
                await _context.AddAsync(InSide);
                await _context.SaveChangesAsync();

                ItemAttachmentType OutSide = new ItemAttachmentType
                {
                    Name = "OutSide"
                };
                await _context.AddAsync(OutSide);
                await _context.SaveChangesAsync();

                ItemAttachmentType VideoLink = new ItemAttachmentType
                {
                    Name = "VideoLink"
                };
                await _context.AddAsync(VideoLink);
                await _context.SaveChangesAsync();

            }

        }
        public static async Task SeedOrderStatusAsync(ApplicationDbContext _context)
        {
            if (_context.OrderStatuses.ToList().Count == 0)
            {
                OrderStatus Received = new OrderStatus
                {
                    Name = "Received",
                    Description = "We received your order"
                };
                await _context.AddAsync(Received);
                await _context.SaveChangesAsync();

                OrderStatus Working = new OrderStatus
                {
                    Name = "Working",
                    Description = "We are working on your order"
                };
                await _context.AddAsync(Working);
                await _context.SaveChangesAsync();

                OrderStatus Shipped = new OrderStatus
                {
                    Name = "Shipped",
                    Description = "We shipped on your order"
                };
                await _context.AddAsync(Shipped);
                await _context.SaveChangesAsync();

                OrderStatus OnShipping = new OrderStatus
                {
                    Name = "IsShipping",
                    Description = "Your order is on shipping"
                };
                await _context.AddAsync(OnShipping);
                await _context.SaveChangesAsync();

                OrderStatus Finished = new OrderStatus
                {
                    Name = "Finish",
                    Description = "We successfully finish shipping"
                };
                await _context.AddAsync(Finished);
                await _context.SaveChangesAsync();

                OrderStatus Pending = new OrderStatus
                {
                    Name = "Sorry",
                    Description = "Sorry, Something went wrong. But we are working on your order"
                };
                await _context.AddAsync(Pending);
                await _context.SaveChangesAsync();
            }
        }
        public static async Task SeedItemSaleOffAsync(ApplicationDbContext _context)
        {
            if (_context.ItemSaleOff.ToList().Count == 0)
            {
                ItemSaleOff None = new ItemSaleOff
                {
                    Name = "None",
                    SalePersentAmount = 0
                };
                await _context.AddAsync(None);
                await _context.SaveChangesAsync();

                ItemSaleOff Five = new ItemSaleOff
                {
                    Name = "-5%",
                    SalePersentAmount = Convert.ToDecimal(5) / Convert.ToDecimal(100)
                };
                await _context.AddAsync(Five);
                await _context.SaveChangesAsync();

                ItemSaleOff Ten = new ItemSaleOff
                {
                    Name = "-10%",
                    SalePersentAmount = Convert.ToDecimal(10) / Convert.ToDecimal(100)
                };
                await _context.AddAsync(Ten);
                await _context.SaveChangesAsync();

                ItemSaleOff Fifthteen = new ItemSaleOff
                {
                    Name = "-15%",
                    SalePersentAmount = Convert.ToDecimal(15) / Convert.ToDecimal(100)
                };
                await _context.AddAsync(Fifthteen);
                await _context.SaveChangesAsync();

                ItemSaleOff Twenty = new ItemSaleOff
                {
                    Name = "-20%",
                    SalePersentAmount = Convert.ToDecimal(20) / Convert.ToDecimal(100)
                };
                await _context.AddAsync(Twenty);
                await _context.SaveChangesAsync();

                ItemSaleOff TwentyFive = new ItemSaleOff
                {
                    Name = "-25%",
                    SalePersentAmount = Convert.ToDecimal(25) / Convert.ToDecimal(100)
                };
                await _context.AddAsync(TwentyFive);
                await _context.SaveChangesAsync();

                ItemSaleOff Thirty = new ItemSaleOff
                {
                    Name = "-30%",
                    SalePersentAmount = Convert.ToDecimal(30) / Convert.ToDecimal(100)
                };
                await _context.AddAsync(Thirty);
                await _context.SaveChangesAsync();

                ItemSaleOff ThirtyFive = new ItemSaleOff
                {
                    Name = "-35%",
                    SalePersentAmount = Convert.ToDecimal(35) / Convert.ToDecimal(100)
                };
                await _context.AddAsync(ThirtyFive);
                await _context.SaveChangesAsync();

                ItemSaleOff Fourty = new ItemSaleOff
                {
                    Name = "-40%",
                    SalePersentAmount = Convert.ToDecimal(40) / Convert.ToDecimal(100)
                };
                await _context.AddAsync(Fourty);
                await _context.SaveChangesAsync();

                ItemSaleOff FourtyFive = new ItemSaleOff
                {
                    Name = "-45%",
                    SalePersentAmount = Convert.ToDecimal(45) / Convert.ToDecimal(100)
                };
                await _context.AddAsync(FourtyFive);
                await _context.SaveChangesAsync();

                ItemSaleOff Fifthty = new ItemSaleOff
                {
                    Name = "-50%",
                    SalePersentAmount = Convert.ToDecimal(50) / Convert.ToDecimal(100)
                };
                await _context.AddAsync(Fifthty);
                await _context.SaveChangesAsync();

                ItemSaleOff FifthtyFive = new ItemSaleOff
                {
                    Name = "-55%",
                    SalePersentAmount = Convert.ToDecimal(55) / Convert.ToDecimal(100)
                };
                await _context.AddAsync(FifthtyFive);
                await _context.SaveChangesAsync();

                ItemSaleOff Sixty = new ItemSaleOff
                {
                    Name = "-60%",
                    SalePersentAmount = Convert.ToDecimal(60) / Convert.ToDecimal(100)
                };
                await _context.AddAsync(Sixty);
                await _context.SaveChangesAsync();

                ItemSaleOff SixtyFive = new ItemSaleOff
                {
                    Name = "-65%",
                    SalePersentAmount = Convert.ToDecimal(65) / Convert.ToDecimal(100)
                };
                await _context.AddAsync(SixtyFive);
                await _context.SaveChangesAsync();

                ItemSaleOff Seventy = new ItemSaleOff
                {
                    Name = "-70%",
                    SalePersentAmount = Convert.ToDecimal(70) / Convert.ToDecimal(100)
                };
                await _context.AddAsync(Seventy);
                await _context.SaveChangesAsync();

                ItemSaleOff SeventyFive = new ItemSaleOff
                {
                    Name = "-75%",
                    SalePersentAmount = Convert.ToDecimal(75) / Convert.ToDecimal(100)
                };
                await _context.AddAsync(SeventyFive);
                await _context.SaveChangesAsync();

                ItemSaleOff Eighty = new ItemSaleOff
                {
                    Name = "-80%",
                    SalePersentAmount = Convert.ToDecimal(80) / Convert.ToDecimal(100)
                };
                await _context.AddAsync(Eighty);
                await _context.SaveChangesAsync();

            }
        }
        public static async Task SeedItemStatusAsync(ApplicationDbContext _context)
        {
            if (_context.ItemStatus.ToList().Count == 0)
            {
                ItemStatus New = new ItemStatus
                {
                    Name = "New"
                };
                await _context.AddAsync(New);
                await _context.SaveChangesAsync();

                ItemStatus Normal = new ItemStatus
                {
                    Name = "Normal"
                };
                await _context.AddAsync(Normal);
                await _context.SaveChangesAsync();

                ItemStatus Hot = new ItemStatus
                {
                    Name = "Hot"
                };
                await _context.AddAsync(Hot);
                await _context.SaveChangesAsync();

                ItemStatus SoldOut = new ItemStatus
                {
                    Name = "Sold Out"
                };
                await _context.AddAsync(SoldOut);
                await _context.SaveChangesAsync();


            }
        }
        public static async Task SeedCategoryAsync(ApplicationDbContext _context, ISlugService _slugService)
        {
            if (_context.Category.ToList().Count() == 0)
            {
                Category Foods = new Category
                {
                    Name = "Food",
                    Description = "Food Food Food Food Food Food",
                    Slug = _slugService.URLFriendly("Food")

                };
                await _context.AddAsync(Foods);
                await _context.SaveChangesAsync();

                Category Drinks = new Category
                {
                    Name = "Drinks",
                    Description = "Drinks Drinks Drinks Drinks Drinks Drinks Drinks Drinks",
                    Slug = _slugService.URLFriendly("Drinks")
                };
                await _context.AddAsync(Drinks);
                await _context.SaveChangesAsync();

                Category Snacks = new Category
                {
                    Name = "Snacks",
                    Description = "Snacks Snacks Snacks Snacks Snacks Snacks Snacks",
                    Slug = _slugService.URLFriendly("Snacks")
                };
                await _context.AddAsync(Snacks);
                await _context.SaveChangesAsync();
            }
        }
        public static async Task SeedRateAsync(ApplicationDbContext _context)
        {
            if (_context.Rate.ToList().Count() == 0)
            {

                Rate Terrible = new Rate
                {
                    Name = "Terrible",
                    Value = 1
                };
                await _context.AddAsync(Terrible);
                await _context.SaveChangesAsync();

                Rate Bad = new Rate
                {
                    Name = "Bad",
                    Value = 2
                };
                await _context.AddAsync(Bad);
                await _context.SaveChangesAsync();

                Rate Medium = new Rate
                {
                    Name = "Medium",
                    Value = 3
                };
                await _context.AddAsync(Medium);
                await _context.SaveChangesAsync();

                Rate Great = new Rate
                {
                    Name = "Great",
                    Value = 4
                };
                await _context.AddAsync(Great);
                await _context.SaveChangesAsync();

                Rate Excellent = new Rate
                {
                    Name = "Excellent",
                    Value = 5
                };
                await _context.AddAsync(Excellent);
                await _context.SaveChangesAsync();
            }
        }
        public static async Task SeedItemAsync(ApplicationDbContext _context, ISlugService _slugService)
        {
            if (_context.Item.ToList().Count == 0)
            {
                var normalItemId = (await _context.ItemStatus.FirstOrDefaultAsync(i => i.Name == "Normal")).Id;
                var NoSaleOffItemId = (await _context.ItemSaleOff.FirstOrDefaultAsync(i => i.Name == "None")).Id;
                var FoodCategoryId = (await _context.Category.FirstOrDefaultAsync(i => i.Name == "Food")).Id;
                var DrinksCategoryId = (await _context.Category.FirstOrDefaultAsync(i => i.Name == "Drinks")).Id;
                var SnacksCategoryId = (await _context.Category.FirstOrDefaultAsync(i => i.Name == "Snacks")).Id;
                var RateId = (await _context.Rate.FirstOrDefaultAsync(i => i.Name == "Excellent")).Id;
                Item item1 = new Item
                {
                    Name = "Snack one",
                    Description = "This snack is a combination flavour of snack one",
                    Price = "1",
                    ImageData = null,
                    ContentType = null,
                    ItemSaleOffId = NoSaleOffItemId,
                    ItemStatusId = normalItemId,
                    CategoryId = SnacksCategoryId,
                    Number_Of_Sold = 0,
                    ViewCount = 0,
                    IsProductReady = true,
                    Slug = _slugService.URLFriendly("Snack one"),
                    RateValue = 5

                };
                await _context.AddAsync(item1);
                await _context.SaveChangesAsync();

                Item item2 = new Item
                {
                    Name = "Snack two",
                    Description = "This snack is a combination flavour of snack two",
                    Price = "2",
                    ImageData = null,
                    ContentType = null,
                    ItemSaleOffId = NoSaleOffItemId,
                    ItemStatusId = normalItemId,
                    CategoryId = SnacksCategoryId,
                    Number_Of_Sold = 0,
                    ViewCount = 0,
                    IsProductReady = true,
                    Slug = _slugService.URLFriendly("Snack two"),
                    RateValue = 5

                };
                await _context.AddAsync(item2);
                await _context.SaveChangesAsync();

                Item item3 = new Item
                {
                    Name = "Snack three",
                    Description = "This snack is a combination flavour of snack three",
                    Price = "1.5",
                    ImageData = null,
                    ContentType = null,
                    ItemSaleOffId = NoSaleOffItemId,
                    ItemStatusId = normalItemId,
                    CategoryId = SnacksCategoryId,
                    Number_Of_Sold = 0,
                    ViewCount = 0,
                    IsProductReady = true,
                    Slug = _slugService.URLFriendly("Snack three"),
                    RateValue = 5

                };
                await _context.AddAsync(item3);
                await _context.SaveChangesAsync();

                Item item4 = new Item
                {
                    Name = "Drinks One",
                    Description = "This drinks is a combination flavour of Drinks One",
                    Price = "1.2",
                    ImageData = null,
                    ContentType = null,
                    ItemSaleOffId = NoSaleOffItemId,
                    ItemStatusId = normalItemId,
                    CategoryId = DrinksCategoryId,
                    Number_Of_Sold = 0,
                    ViewCount = 0,
                    IsProductReady = true,
                    Slug = _slugService.URLFriendly("Drinks One"),
                    RateValue = 5

                };
                await _context.AddAsync(item4);
                await _context.SaveChangesAsync();

                Item item5 = new Item
                {
                    Name = "Drinks Two",
                    Description = "This drinks is a combination flavour of Drinks Two",
                    Price = "0.7",
                    ImageData = null,
                    ContentType = null,
                    ItemSaleOffId = NoSaleOffItemId,
                    ItemStatusId = normalItemId,
                    CategoryId = DrinksCategoryId,
                    Number_Of_Sold = 0,
                    ViewCount = 0,
                    IsProductReady = true,
                    Slug = _slugService.URLFriendly("Drinks Two"),
                    RateValue = 5


                };
                await _context.AddAsync(item5);
                await _context.SaveChangesAsync();

                Item item6 = new Item
                {
                    Name = "Drinks Three",
                    Description = "This drinks is a combination flavour of Drinks Three",
                    Price = "0.5",
                    ImageData = null,
                    ContentType = null,
                    ItemSaleOffId = NoSaleOffItemId,
                    ItemStatusId = normalItemId,
                    CategoryId = DrinksCategoryId,
                    Number_Of_Sold = 0,
                    ViewCount = 0,
                    IsProductReady = true,
                    Slug = _slugService.URLFriendly("Drinks Three"),
                    RateValue = 5

                };
                await _context.AddAsync(item6);
                await _context.SaveChangesAsync();

                Item item7 = new Item
                {
                    Name = "Food One",
                    Description = "This Food is a combination flavour of Food One",
                    Price = "1.25",
                    ImageData = null,
                    ContentType = null,
                    ItemSaleOffId = NoSaleOffItemId,
                    ItemStatusId = normalItemId,
                    CategoryId = FoodCategoryId,
                    Number_Of_Sold = 0,
                    ViewCount = 0,
                    IsProductReady = true,
                    Slug = _slugService.URLFriendly("Food One"),
                    RateValue = 5

                };
                await _context.AddAsync(item7);
                await _context.SaveChangesAsync();

                Item item8 = new Item
                {
                    Name = "Food Two",
                    Description = "This Food is a combination flavour of Food Two",
                    Price = "1.75",
                    ImageData = null,
                    ContentType = null,
                    ItemSaleOffId = NoSaleOffItemId,
                    ItemStatusId = normalItemId,
                    CategoryId = FoodCategoryId,
                    Number_Of_Sold = 0,
                    ViewCount = 0,
                    IsProductReady = true,
                    Slug = _slugService.URLFriendly("Food Two"),
                    RateValue = 5

                };
                await _context.AddAsync(item8);
                await _context.SaveChangesAsync();

                Item item9 = new Item
                {
                    Name = "Food Three",
                    Description = "This Food is a combination flavour of Food Three",
                    Price = "1.75",
                    ImageData = null,
                    ContentType = null,
                    ItemSaleOffId = NoSaleOffItemId,
                    ItemStatusId = normalItemId,
                    CategoryId = FoodCategoryId,
                    Number_Of_Sold = 0,
                    ViewCount = 0,
                    IsProductReady = true,
                    Slug = _slugService.URLFriendly("Food Three"),
                    RateValue = 5

                };
                await _context.AddAsync(item9);
                await _context.SaveChangesAsync();

                Item item10 = new Item
                {
                    Name = "Food Four",
                    Description = "This Food is a combination flavour of Food Four",
                    Price = "1.30",
                    ImageData = null,
                    ContentType = null,
                    ItemSaleOffId = NoSaleOffItemId,
                    ItemStatusId = normalItemId,
                    CategoryId = FoodCategoryId,
                    Number_Of_Sold = 0,
                    ViewCount = 0,
                    IsProductReady = true,
                    Slug = _slugService.URLFriendly("Food Four"),
                    RateValue = 5

                };
                await _context.AddAsync(item10);
                await _context.SaveChangesAsync();
            }

        }
        private static async Task SeedRoleAsync(RoleManager<IdentityRole> roleSvc)
        {
            // call upon the roleSvc to add the new role
            await roleSvc.CreateAsync(new IdentityRole("Administrator"));
            await roleSvc.CreateAsync(new IdentityRole("Moderator"));
            await roleSvc.CreateAsync(new IdentityRole("TemporaryUser"));
            await roleSvc.CreateAsync(new IdentityRole("NormalUser"));
        }
        private static async Task SeedUserAsync(UserManager<CustomUser> userManagerSvc)
        {
            //create your self as a user

            var adminUser = new CustomUser()
            {
                Email = "arthastheking113@gmail.com",
                UserName = "arthastheking113@gmail.com",
                FirstName = "Lan",
                LastName = "Le",
                PhoneNumber = "4023040329",
                EmailConfirmed = true

            };
            await userManagerSvc.CreateAsync(adminUser, "Abc123!");
            //create someone else as a moderator
            var modUser = new CustomUser()
            {
                Email = "mcmacay113@yahoo.com",
                UserName = "mcmacay113@yahoo.com",
                FirstName = "Lan 2",
                LastName = "Le 2",
                PhoneNumber = "4023040329",
                EmailConfirmed = true

            };
            await userManagerSvc.CreateAsync(modUser, "Abc123!");
        }
        private static async Task AssignRoleAsync(UserManager<CustomUser> userManagerSvc)
        {
            // get a reference to the admin user
            var adminUser = await userManagerSvc.FindByEmailAsync("arthastheking113@gmail.com");
            await userManagerSvc.AddToRoleAsync(adminUser, "Administrator");
            var modUser = await userManagerSvc.FindByEmailAsync("mcmacay113@yahoo.com");
            await userManagerSvc.AddToRoleAsync(modUser, "Moderator");
        }
    }
}
