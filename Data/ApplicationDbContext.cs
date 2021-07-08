using BlazorStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Rate> Rate { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<ItemSaleOff> ItemSaleOff { get; set; }
        public DbSet<ItemStatus> ItemStatus { get; set; }
        public DbSet<ItemAttachment> ItemAttachment { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<ItemAttachmentType> ItemAttachmentTypes { get; set; }
        public DbSet<WishList> WishList { get; set; }


        public DbSet<BlogCategory> BlogCategory { get; set; }
        public DbSet<BlogPost> PostCategory { get; set; }
        public DbSet<BlogComment> PostComment { get; set; }
        public DbSet<BlogTag> BlogTag { get; set; }
    }
}
