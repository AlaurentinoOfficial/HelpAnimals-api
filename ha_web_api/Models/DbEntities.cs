using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ha_web_api.Models
{
    public class DbEntities : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=helpanimals.database.windows.net;Initial Catalog=TestNetCoreEF;user id=alaurentino;password=!Jimmy123;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
