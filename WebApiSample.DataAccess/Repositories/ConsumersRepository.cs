using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiSample.DataAccess.Models;

namespace WebApiSample.DataAccess.Repositories
{
    public class ConsumersRepository
    {
        private readonly ConsumerContext _context;

        public ConsumersRepository(ConsumerContext context)
        {
            _context = context;

            if (_context.Consumers.Count() == 0)
            {
                _context.Consumers.AddRange(
                    new Consumer
                    {
                        Name = "Opie",
                        Location = "Shih Tzu",
                        ConsumerType = ConsumerType.Agent
                    },
                    new Consumer
                    {
                        Name = "Reggie",
                        Location = "Beagle",
                        ConsumerType = ConsumerType.Agent
                    },
                    new Consumer
                    {
                        Name = "Diesel",
                        Location = "Bombay",
                        ConsumerType = ConsumerType.User
                    },
                    new Consumer
                    {
                        Name = "Lucy",
                        Location = "Maine Coon",
                        ConsumerType = ConsumerType.User
                    });
                _context.SaveChanges();
            }
        }

        public async Task<List<Consumer>> GetConsumersAsync()
        {
            return await _context.Consumers.ToListAsync();
        }

        public async Task<Consumer> GetConsumerAsync(int id)
        {
            return await _context.Consumers.FindAsync(id);
        }

        public async Task<int> AddConsumerAsync(Consumer consumer)
        {
            int rowsAffected = 0;

            _context.Consumers.Add(consumer);
            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }

        public async Task<int> DeleteConsumerAsync(int id)
        {
            int rowsAffected = 0;

            var consumer = await _context.Consumers.FindAsync(id);

            if (consumer == null)
            {
                return rowsAffected;
            }
            else
            {
                _context.Consumers.Remove(consumer);
                rowsAffected = await _context.SaveChangesAsync();
            }

            return rowsAffected;
             
        }
    }
}
