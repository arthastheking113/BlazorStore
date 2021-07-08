using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Services
{
    public interface ICanUserComment
    {
        public Task AddUserToItemAsync(string userId, int itemId);

        public Task RemoveUserFromItemAsync(string userId, int itemId);

        public Task<bool> IsUserInItemAsync(string userId, int itemId);
    }
}
