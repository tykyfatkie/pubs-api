using pubs1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace pubs1.Services
{
    public class TitleService : ITitleService
    {
        private readonly PUBSContext _context;

        public TitleService(PUBSContext context)
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
            await _context.Titles.AddAsync(title);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTitleAsync(Title title)
        {
            var existingTitle = await _context.Titles.FindAsync(title.TitleId);
            if (existingTitle != null)
            {
                existingTitle.Title1 = title.Title1;
                existingTitle.Type = title.Type;
                existingTitle.PubId = title.PubId;
                existingTitle.Price = title.Price;
                existingTitle.Advance = title.Advance;
                existingTitle.Royalty = title.Royalty;
                existingTitle.YtdSales = title.YtdSales;
                existingTitle.Notes = title.Notes;
                existingTitle.Pubdate = title.Pubdate;

                _context.Titles.Update(existingTitle);
                await _context.SaveChangesAsync();
            }
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
