using System.Collections.Generic;
using System.Threading.Tasks;
using pubs1.Models;

namespace pubs1.Services.Interface
{
    public interface IStoreService
    {
        Task<IEnumerable<Store>> GetAllStoresAsync();
        Task<Store> GetStoreByIdAsync(string id);
        Task<Store> AddStoreAsync(Store newStore);
        Task<Store> UpdateStoreAsync(string id, Store updatedStore);
        Task<bool> DeleteStoreAsync(string id);
    }
}
