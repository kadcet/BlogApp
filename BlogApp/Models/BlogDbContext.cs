using Microsoft.EntityFrameworkCore;

namespace BlogApp.Models
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}
