using CLEAN_Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLEAN_Infrastructure_DATA.Context
{
    public class KnowledgeBaseContext : DbContext
    {
        public KnowledgeBaseContext(DbContextOptions<KnowledgeBaseContext> options) : base(options)
        {

        }
        public DbSet<ArticleModel> ARTICLE { get; set; }

        public DbSet<CommentsModel> ARTICLE_COMMENTS { get; set; }
    }

    
}
