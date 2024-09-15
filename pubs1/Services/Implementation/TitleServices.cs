using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pubs1.Models;
using pubs1.Services.Interface;

namespace pubs1.Services.Implementation
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

        public async Task<Title> GetTitleByIdAsync(string id)
        {
            return await _context.Titles.FindAsync(id);
        }

        public async Task<Title> AddTitleAsync(Title newTitle)
        {
            _context.Titles.Add(newTitle);
            await _context.SaveChangesAsync();
            return newTitle;
        }

        public async Task<Title> UpdateTitleAsync(string id, Title updatedTitle)
        {
            var existingTitle = await _context.Titles.FindAsync(id);
            if (existingTitle == null)
            {
                return null;
            }

            // Cập nhật các thuộc tính của existingTitle bằng giá trị từ updatedTitle
            existingTitle.Title1 = updatedTitle.Title1;
            existingTitle.Type = updatedTitle.Type;
            existingTitle.PubId = updatedTitle.PubId;
            existingTitle.Price = updatedTitle.Price;
            existingTitle.Advance = updatedTitle.Advance;
            existingTitle.Royalty = updatedTitle.Royalty;
            existingTitle.YtdSales = updatedTitle.YtdSales;
            existingTitle.Notes = updatedTitle.Notes;
            existingTitle.Pubdate = updatedTitle.Pubdate;

            await _context.SaveChangesAsync();
            return existingTitle;
        }

        public async Task<bool> DeleteTitleAsync(string id)
        {
            var title = await _context.Titles.FindAsync(id);
            if (title == null)
            {
                return false;
            }

            _context.Titles.Remove(title);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<Title>> GetAllTitleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
