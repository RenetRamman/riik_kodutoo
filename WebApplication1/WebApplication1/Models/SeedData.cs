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
            if (!context.EventModel.Any())
            {
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
            }


            // Look for any persons.
            if (!context.PersonModel.Any())
            {
                context.PersonModel.AddRange(
                new PersonModel
                {
                    FirstName = "Bob",
                    LastName = "Bobson",
                    PersonalId = 1234567890,
                    PayingMethod = false,
                    AdditionalInfo = ""
                }
                );
            }

            // Look for any persons participating in specific events.
            if (!context.EventPersonModel.Any())
            {
                context.EventPersonModel.AddRange(
                new EventPersonModel
                {
                    EventModelID = 4,
                    PersonModelID = 1
                },
                new EventPersonModel
                {
                    EventModelID = 7,
                    PersonModelID = 1
                }
            );
            }
                context.SaveChanges();
        }
    }
}