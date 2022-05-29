using Microsoft.EntityFrameworkCore;

namespace GameDB
{
    public class GameDbContext : DbContext
    {
        public GameDbContext (DbContextOptions<GameDbContext> options) : base(options)
        {

        }
    }
}
