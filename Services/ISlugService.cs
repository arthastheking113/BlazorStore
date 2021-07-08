using BlazorStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Services
{
    public interface ISlugService
    {
        string URLFriendly(string title);

        bool IsUnique(ApplicationDbContext dbContext, string slug);
        bool IsUniqueCategory(ApplicationDbContext dbContext, string slug);

        bool IsUniqueBlog(ApplicationDbContext dbContext, string slug);

        bool IsUniquePost(ApplicationDbContext dbContext, string slug);
    }
}
