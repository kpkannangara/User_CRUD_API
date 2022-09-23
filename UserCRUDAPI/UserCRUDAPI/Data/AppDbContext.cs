using Microsoft.EntityFrameworkCore;
using UserCRUDAPI.Models;

namespace UserCRUDAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<UserDetails> Users { get; set; }


    }
}
