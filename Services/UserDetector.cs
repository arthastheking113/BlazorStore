using BlazorStore.Data;
using BlazorStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Services
{
    public class UserDetector : IUserDetector
    {
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly UserManager<CustomUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserDetector> _logger;
        private readonly HttpContext _httpContext;

        public UserDetector(
            IActionContextAccessor actionContextAccessor,
            UserManager<CustomUser> userManager,
            ApplicationDbContext context,
            ILogger<UserDetector> logger,
            HttpContext httpContext)
        {
            _actionContextAccessor = actionContextAccessor;
            _userManager = userManager;
            _context = context;
            _logger = logger;
            _httpContext = httpContext;
        }
        public string GetUserIpAdress()
        {

            string ip = _httpContext.Connection.RemoteIpAddress.ToString();

            //string ip = _actionContextAccessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString();
            return ip;
        }

        public string GetUserConnectionId()
        {
            //string ConnectionId = _actionContextAccessor.ActionContext.HttpContext.Connection.Id;
            string ConnectionId = _httpContext.Connection.Id;
            return ConnectionId;
        }

        public async Task CreateTemporaryUserAsync()
        {
            string IpAdress = GetUserIpAdress();
            string connectionId = GetUserConnectionId();
            if (_context.Users.FirstOrDefault(u => u.IpAdress == IpAdress && u.ConnectionId == connectionId) == null)
            {
                var NumberOfUser = _context.Users.ToList().Count() + 1;
                var tempEmail = "tempUser" + NumberOfUser.ToString() + "@lanonlinemarket.com";
                var userName = tempEmail;

                var user = new CustomUser
                {
                    UserName = userName,
                    Email = tempEmail,
                    FirstName = "User",
                    LastName = $"#{NumberOfUser}",
                    IpAdress = IpAdress,
                    ConnectionId = connectionId,
                    ImageData = null,
                    ContentType = null,
                    Street = null,
                    State = null,
                    City = null,
                    Zipcode = null,
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(user, "Abc123!");
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    await _userManager.AddToRoleAsync(user, "TemporaryUser");
                }
            }

        }
    }
}
