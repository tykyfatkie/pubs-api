using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pubs1.Models;
using pubs1.Services.Interface;

namespace pubs1.Services.Implementation
{
    public class StoreService : IStoreService
    {
        private readonly PUBSContext _context;

        public StoreService(PUBSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Store>> GetAllStoresAsync()
        {
            return await _context.Stores.ToListAsync();
        }

        public async Task<Store> GetStoreByIdAsync(string id)
        {
            return await _context.Stores.FindAsync(id);
        }

        public async Task<Store> AddStoreAsync(Store newStore)
        {
            _context.Stores.Add(newStore);
            await _context.SaveChangesAsync();
            return newStore;
        }

        public async Task<Store> UpdateStoreAsync(string id, Store updatedStore)
        {
            var existingStore = await _context.Stores.FindAsync(id);
            if (existingStore == null)
            {
                return null;
            }

            // Cập nhật các thuộc tính của existingStore từ updatedStore
            existingStore.StorName = updatedStore.StorName;
            existingStore.StorAddress = updatedStore.StorAddress;
            existingStore.City = updatedStore.City;
            existingStore.State = updatedStore.State;
            existingStore.Zip = updatedStore.Zip;

            await _context.SaveChangesAsync();
            return existingStore;
        }

        public async Task<bool> DeleteStoreAsync(string id)
        {
            var store = await _context.Stores.FindAsync(id);
            if (store == null)
            {
                return false;
            }

            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
