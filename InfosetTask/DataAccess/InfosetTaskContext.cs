using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InfosetTask.Models
{
    public class InfosetTaskContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=KORKMAZ\SQLEXPRESS;Database=InfosetTask;Trusted_Connection=true");
        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
