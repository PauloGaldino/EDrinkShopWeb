using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EDrinkShop.ApplicationCore.Entities;

namespace EDrinkWeb.UI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EDrinkShop.ApplicationCore.Entities.CalalogItem> CalalogItem { get; set; }
    }
}
