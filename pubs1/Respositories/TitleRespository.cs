using Microsoft.EntityFrameworkCore;
using pubs1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pubs1.Repositories
{
    public class TitleRepository : ITitleRepository
    {
        private readonly PUBSContext _context;

        public TitleRepository(PUBSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Title>> GetAllTitlesAsync()
        {
            return await _context.Titles.ToListAsync();
        }

        public async Task<Title> GetTitleByIdAsync(string titleId)
        {
            return await _context.Titles.FindAsync(titleId);
        }

        public async Task AddTitleAsync(Title title)
        {
            _context.Titles.Add(title);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTitleAsync(Title title)
        {
            _context.Entry(title).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTitleAsync(string titleId)
        {
            var title = await _context.Titles.FindAsync(titleId);
            if (title != null)
            {
                _context.Titles.Remove(title);
                await _context.SaveChangesAsync();
            }
        }
    }
}
