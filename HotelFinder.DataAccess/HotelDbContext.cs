using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.DataAccess
{
    class HotelDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("DESKTOP-PFPOMJ9/SQLEXPRESS;Database=HotelDb;");
            optionsBuilder.UseSqlServer("Data source=DESKTOP-PFPOMJ9\\SQLEXPRESS;Database=HotelDb;uid = sa;pwd = 1234;");
            //uid = sa; pwd = 1234
         
        }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
