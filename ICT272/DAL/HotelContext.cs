using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ICT272.Models;

namespace ICT272.DAL
{
    public class HotelContext : DbContext
    {
        public HotelContext() : base("HotelContext")
        {

        }
    
        public System.Data.Entity.DbSet<Event> Events  { get; set; }
        public System.Data.Entity.DbSet<EventType> EventTypes { get; set; }

        public System.Data.Entity.DbSet<Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<Role> Roles { get; set; }

        public System.Data.Entity.DbSet<UserRoles> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

