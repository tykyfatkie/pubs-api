using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using pubs1.Models;

namespace pubs1.Services.Interface
{
    public interface ITitleService
    {
        Task<IEnumerable<pubs1.Models.Title>> GetAllTitleAsync();
        Task<pubs1.Models.Title> GetTitleByIdAsync(string id);
        Task<pubs1.Models.Title> AddTitleAsync(pubs1.Models.Title newTitle);
        Task<pubs1.Models.Title> UpdateTitleAsync(string id, pubs1.Models.Title updatedTitle);

    }
}
