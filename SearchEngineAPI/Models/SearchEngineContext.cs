using Microsoft.EntityFrameworkCore;

namespace SearchEngineAPI.Models
{
    public class SearchEngineContext : DbContext
    {
        public SearchEngineContext(DbContextOptions<SearchEngineContext> options)
            : base(options)
        {
        }

        public DbSet<SearchItem> SearchItems { get; set; }
    }
}
