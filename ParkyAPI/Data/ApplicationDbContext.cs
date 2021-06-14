using Microsoft.EntityFrameworkCore;
using ParkyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }


        public DbSet<NationalPark> NationalPark { get; set; }

        public DbSet<Trail> Trail { get; set; }

        public DbSet<User> User { get; set; }
    }
}
