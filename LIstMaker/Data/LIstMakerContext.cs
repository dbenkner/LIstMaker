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
    }
}
