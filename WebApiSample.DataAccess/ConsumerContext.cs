using Microsoft.EntityFrameworkCore;
using WebApiSample.DataAccess.Models;

namespace WebApiSample.DataAccess
{
    public class ConsumerContext : DbContext
    {
        public ConsumerContext(DbContextOptions<ConsumerContext> options)
            : base(options)
        {
        }

        public DbSet<Consumer> Consumers { get; set; }
    }
}
