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
                // Look for any Comments.
                if (context.Comment.Any())
                {
                    return;   // DB has been seeded
                }

                context.Comment.AddRange(
                    new Comment
                    {
                        ReportId = 1,
                        CreatedBy = Guid.Parse("e03056cf-7146-483f-a86f-e41f8332060d"),
                        CommentText = "What an amazing story!",
                        CreatedDate = DateTime.Parse("2022-4-12"),
                        UpdatedDate = DateTime.Parse("2022-5-12")
                    },
                    new Comment
                    {
                        ReportId = 1,
                        CreatedBy = Guid.Parse("e03056cf-7146-483f-a86f-e41f8332060d"),
                        CommentText = "That made my day ....",
                        CreatedDate = DateTime.Parse("2022-4-12"),
                        UpdatedDate = DateTime.Parse("2022-5-12")
                    },
                    new Comment
                    {
                        ReportId = 3,
                        CreatedBy = Guid.Parse("e03056cf-7146-483f-a86f-e41f8332060d"),
                        CommentText = "I can't say I agree at all !",
                        CreatedDate = DateTime.Parse("2022-4-12"),
                        UpdatedDate = DateTime.Parse("2022-5-12")
                    },
                    new Comment
                    {
                        ReportId = 3,
                        CreatedBy = Guid.Parse("e03056cf-7146-483f-a86f-e41f8332060d"),
                        CommentText = "I'll never get that 5 minutes back again !! ",
                        CreatedDate = DateTime.Parse("2022-4-12"),
                        UpdatedDate = DateTime.Parse("2022-5-12")
                    },
                    new Comment
                    {
                        ReportId = 4,
                        CreatedBy = Guid.Parse("e03056cf-7146-483f-a86f-e41f8332060d"),
                        CommentText = "More news stories like this please .... ",
                        CreatedDate = DateTime.Parse("2022-4-12"),
                        UpdatedDate = DateTime.Parse("2022-5-12")
                    },
                    new Comment
                    {
                        ReportId = 4,
                        CreatedBy = Guid.Parse("e03056cf-7146-483f-a86f-e41f8332060d"),
                        CommentText = "What an interesting read. ",
                        CreatedDate = DateTime.Parse("2022-4-12"),
                        UpdatedDate = DateTime.Parse("2022-5-12")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}