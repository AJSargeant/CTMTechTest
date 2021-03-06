using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTMTechTest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Transaction> Transaction { get; set; }
        public DbSet<Models.Merchant> Merchant { get; set; }
        public DbSet<Models.User> User { get; set; }
    }
}
