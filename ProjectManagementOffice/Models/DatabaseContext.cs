using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementOffice.Models
{
    public class DatabaseContext : DbContext
    {
        private readonly DbContextOptions context;
        
        public DatabaseContext(DbContextOptions options):base(options)
        {
            context = options;
        }

        public DbSet<Members> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
