using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DBCon
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<User> tbl_User { get; set; }
        public DbSet<Leads> Lead { get; set; }

        public DbSet<Refreshusing> tbl_Refreshtoken { get; set; }


        public DbSet<Opportunity> Opportunities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-TK1M66N\MSSQLSERVER01;Initial Catalog=Sri;Integrated Security=True");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
