using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ListMaker.Models;

namespace ListMaker.Data
{
    public class ListMakerContext : DbContext
    {
        public ListMakerContext (DbContextOptions<ListMakerContext> options)
            : base(options)
        {
        }

        public DbSet<ListMaker.Models.User> Users { get; set; } = default!;
        public DbSet<ListMaker.Models.ListCategory> ListCategories { get; set; } = default!;
        public DbSet<ListMaker.Models.List> Lists { get; set; } = default!;
        public DbSet<ListMaker.Models.ItemCategory> ItemCategories { get; set; }
    }
}
