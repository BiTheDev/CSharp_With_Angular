using Microsoft.EntityFrameworkCore;
    
    namespace Combine.Models
    {
        public class CombineContext : DbContext
        {
            public CombineContext(DbContextOptions<CombineContext> options) : base(options) { }

            public DbSet<Users> Users { get; set; }

        }
    }