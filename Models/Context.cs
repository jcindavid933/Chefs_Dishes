using Microsoft.EntityFrameworkCore;

namespace chefs_dishes.Models
{
    public class Context : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Context(DbContextOptions<Context> options) : base(options) { }
	    public DbSet<Chef> Chef { get; set; }
        public DbSet<Dishes> Dishes { get; set; }

    }
}
