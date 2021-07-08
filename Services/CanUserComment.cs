using BlazorStore.Data;
using BlazorStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Services
{
    public class CanUserComment : ICanUserComment
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CustomUser> _userManager;

        public CanUserComment(ApplicationDbContext context,
            UserManager<CustomUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> IsUserInItemAsync(string userId, int itemId)
        {
            var item = await _context.Item.Include(p => p.CustomUsers).FirstAsync(c => c.Id == itemId);
            var user = item.CustomUsers.Any(u => u.Id == userId);
            return user;
        }

        public async Task AddUserToItemAsync(string userId, int itemId)
        {
            try
            {
                if (!await IsUserInItemAsync(userId, itemId))
                {
                    CustomUser user = await _userManager.FindByIdAsync(userId);

                    Item item = await _context.Item.FindAsync(itemId);
                    try
                    {
                        item.CustomUsers.Add(user);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"*** ERROR *** - Error Adding user to project - message:{ex.Message}");
            }
        }

        public async Task RemoveUserFromItemAsync(string userId, int itemId)
        {
            try
            {
                if (await IsUserInItemAsync(userId, itemId))
                {
                    CustomUser user = await _userManager.FindByIdAsync(userId);
                    Item item = await _context.Item.FindAsync(itemId);
                    try
                    {
                        item.CustomUsers.Remove(user);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"*** ERROR *** - Error Remove user to project - message:{ex.Message}");
            }
        }
    }
}
