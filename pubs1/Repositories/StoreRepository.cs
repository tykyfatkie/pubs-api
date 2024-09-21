using Microsoft.EntityFrameworkCore;
using pubs1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pubs1.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly PUBSContext _context;

        public StoreRepository(PUBSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Store>> GetAllStoresAsync()
        {
            return await _context.Stores.ToListAsync();
        }

        public async Task<Store> GetStoreByIdAsync(string storId)
        {
            return await _context.Stores.FindAsync(storId);
        }

        public async Task AddStoreAsync(Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStoreAsync(Store store)
        {
            _context.Entry(store).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStoreAsync(string storId)
        {
            var store = await _context.Stores.FindAsync(storId);
            if (store != null)
            {
                _context.Stores.Remove(store);
                await _context.SaveChangesAsync();
            }
        }
    }
}
