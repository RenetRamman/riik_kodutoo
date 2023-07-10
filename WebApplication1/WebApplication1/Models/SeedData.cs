using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Data;
using System;
using System.Linq;

namespace WebApplication1.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new WebApplication1Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<WebApplication1Context>>()))
        {
            // Look for any movies.
            if (context.EventModel.Any())
            {
                return;   // DB has been seeded
            }
            context.EventModel.AddRange(
                new EventModel
                {
                    Title = "aenean commodo",
                    Date = DateTime.Parse("2016-2-14"),
                    Location = "Tallinn",
                    AdditionalInfo = ""
                },
                new EventModel
                {
                    Title = "Fusce ex dui, finibus eu luctus vel",
                    Date = DateTime.Parse("2016-2-18"),
                    Location = "Põlva",
                    AdditionalInfo = "Väga oluline lisainfo"
                },
                new EventModel
                {
                    Title = "asd qwe",
                    Date = DateTime.Parse("2018-3-14"),
                    Location = "Tartu",
                    AdditionalInfo = ""
                }
            );
            context.SaveChanges();
        }
    }
}