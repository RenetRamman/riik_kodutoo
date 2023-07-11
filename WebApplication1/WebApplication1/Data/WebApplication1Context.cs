using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WebApplication1Context : DbContext
    {
        public WebApplication1Context (DbContextOptions<WebApplication1Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.EventModel> EventModel { get; set; } = default!;
        public DbSet<WebApplication1.Models.PersonModel> PersonModel { get; set; } = default!;
        public DbSet<WebApplication1.Models.CompanyModel> CompanyModel { get; set; } = default!;
        public DbSet<WebApplication1.Models.EventPersonModel> EventPersonModel { get; set; } = default!;
        public DbSet<WebApplication1.Models.EventCompanyModel> EventCompanyModel { get; set; } = default!;
    }
}
