using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PoolsExample.Models
{
    public class PoolsDbContext : DbContext
    {

        //5
        public PoolsDbContext() : base("PoolsDB") { }

        public DbSet<Bookings> bookings { get; set; }
        public DbSet<Timeclass> time { get; set; }
        public DbSet<Pools> pool { get; set; }
    }
}