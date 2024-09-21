using pubs1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pubs1.Services
{
    public interface ITitleService
    {
        Task<IEnumerable<Title>> GetAllTitlesAsync();
        Task<Title> GetTitleByIdAsync(string titleId);
        Task AddTitleAsync(Title title);
        Task UpdateTitleAsync(Title title);
        Task DeleteTitleAsync(string titleId);
    }
}
