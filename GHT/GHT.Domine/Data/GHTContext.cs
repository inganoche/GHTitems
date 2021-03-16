using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHT.Core.Entities;

namespace GHT.Domine.Data
{
     public class GHTContext : DbContext
    {
        public GHTContext(DbContextOptions<GHTContext> options) : base(options) { }

        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Buys> Buys { get; set; }
    }
}
