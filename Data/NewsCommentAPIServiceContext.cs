#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsCommentAPIService.Models;

namespace NewsCommentAPIService.Data
{
    public class NewsCommentAPIServiceContext : DbContext
    {
        public NewsCommentAPIServiceContext (DbContextOptions<NewsCommentAPIServiceContext> options)
            : base(options)
        {
        }

        public DbSet<NewsCommentAPIService.Models.Comment> Comment { get; set; }
    }
}
