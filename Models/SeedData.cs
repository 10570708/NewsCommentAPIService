using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsCommentAPIService.Data;
using System;
using System.Linq;

namespace NewsCommentAPIService.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NewsCommentAPIServiceContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<NewsCommentAPIServiceContext>>()))
            {
                // Look for any movies.
 //               if (context.Report.Any())
 //               {
 //                   return;   // DB has been seeded
 //               }

                context.Comment.AddRange(
                    new Comment
                    {
                        ReportId = 46,
                        CreatedBy = Guid.Parse("e03056cf-7146-483f-a86f-e41f8332060d"),
                        CommentText = "What an amazing story!",
                        CreatedDate = DateTime.Parse("2022-4-12"),
                        UpdatedDate = DateTime.Parse("2022-5-12")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}