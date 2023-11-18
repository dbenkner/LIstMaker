using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LIstMaker.Models;

namespace LIstMaker.Data
{
    public class LIstMakerContext : DbContext
    {
        public LIstMakerContext (DbContextOptions<LIstMakerContext> options)
            : base(options)
        {
        }

        public DbSet<LIstMaker.Models.User> Users { get; set; } = default!;
        public DbSet<ListMaker.Models.ListCategory> ListCategories { get; set; } = default!;
        public DbSet<LIstMaker.Models.List> Lists { get; set; } = default!;
        public DbSet<ListMaker.Models.ItemCategory> ItemCategories { get; set; }
    }
}
