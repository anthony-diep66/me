using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Me.Data;
using System;
using System.Linq;

namespace Me.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MeContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MeContext>>()))
            {
                // look for any hobbies 
                if (context.Hobby!.Any())
                {
                    return; // DB has been seeded
                }
                context.Hobby.AddRange(
                    new Hobby
                    {
                        Name = "Penetrating Myself",
                        Description = "Sticking a bbc into my cute asshole",
                        LastWorkedOn = DateTime.Now,
                        Rating = "**"
                    },
                    new Hobby
                    {
                        Name = "Twerking",
                        Description = "Twerking on a pillow until I cum",
                        LastWorkedOn = DateTime.Now,
                        Rating = "**"

                    },
                    new Hobby
                    {
                        Name = "Chastity",
                        Description = "Putting myself into a chastity so I dont get hard",
                        LastWorkedOn = DateTime.Now,
                        Rating = "****"
                    },
                    new Hobby
                    {
                        Name = "Thongs",
                        Description = "Posing in my cute thong",
                        LastWorkedOn = DateTime.Now,
                        Rating = "*****"
                    }
                ); ;
                context.SaveChanges();
            }
        }
    }
}
