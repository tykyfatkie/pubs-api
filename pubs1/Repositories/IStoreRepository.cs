using pubs1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pubs1.Repositories
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetAllStoresAsync();
        Task<Store> GetStoreByIdAsync(string storId);
        Task AddStoreAsync(Store store);
        Task UpdateStoreAsync(Store store);
        Task DeleteStoreAsync(string storId);
    }
}
