using Microsoft.AspNetCore.Mvc;
using pubs1.Models;
using pubs1.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pubs1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private readonly ITitleService _titleService;

        public TitleController(ITitleService titleService)
        {
            _titleService = titleService;
        }

        // GET: api/Title
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Title>>> GetAllTitles()
        {
            var titles = await _titleService.GetAllTitlesAsync();
            return Ok(titles);
        }

        // GET: api/Title/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Title>> GetTitleById(string id)
        {
            var title = await _titleService.GetTitleByIdAsync(id);

            if (title == null)
            {
                return NotFound();
            }

            return Ok(title);
        }

        // POST: api/Title
        [HttpPost]
        public async Task<ActionResult> AddTitle([FromBody] Title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _titleService.AddTitleAsync(title);
            return CreatedAtAction(nameof(GetTitleById), new { id = title.TitleId }, title);
        }

        // PUT: api/Title/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTitle(string id, [FromBody] Title title)
        {
            if (id != title.TitleId)
            {
                return BadRequest("Title ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingTitle = await _titleService.GetTitleByIdAsync(id);
            if (existingTitle == null)
            {
                return NotFound();
            }

            await _titleService.UpdateTitleAsync(title);
            return NoContent();
        }

        // DELETE: api/Title/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitle(string id)
        {
            var title = await _titleService.GetTitleByIdAsync(id);
            if (title == null)
            {
                return NotFound();
            }

            await _titleService.DeleteTitleAsync(id);
            return NoContent();
        }
    }
}
