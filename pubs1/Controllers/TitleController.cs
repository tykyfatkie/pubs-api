using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pubs1.Models;
using pubs1.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pubs1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private readonly ITitleRepository _repository;

        public TitleController(ITitleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Title>>> GetTitles()
        {
            var titles = await _repository.GetAllTitlesAsync();
            return Ok(titles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Title>> GetTitle(string id)
        {
            var title = await _repository.GetTitleByIdAsync(id);
            if (title == null)
            {
                return NotFound();
            }
            return Ok(title);
        }

        [HttpPost]
        public async Task<ActionResult<Title>> CreateTitle(Title title)
        {
            await _repository.AddTitleAsync(title);
            return CreatedAtAction(nameof(GetTitle), new { id = title.TitleId }, title);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTitle(string id, Title title)
        {
            if (id != title.TitleId)
            {
                return BadRequest();
            }

            try
            {
                await _repository.UpdateTitleAsync(title);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _repository.GetTitleByIdAsync(id) == null)
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitle(string id)
        {
            await _repository.DeleteTitleAsync(id);
            return NoContent();
        }
    }
}
