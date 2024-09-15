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
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _repository;

        public StoreController(IStoreRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Store>>> GetStores()
        {
            var stores = await _repository.GetAllStoresAsync();
            return Ok(stores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> GetStore(string id)
        {
            var store = await _repository.GetStoreByIdAsync(id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        [HttpPost]
        public async Task<ActionResult<Store>> CreateStore(Store store)
        {
            await _repository.AddStoreAsync(store);
            return CreatedAtAction(nameof(GetStore), new { id = store.StorId }, store);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStore(string id, Store store)
        {
            if (id != store.StorId)
            {
                return BadRequest();
            }

            try
            {
                await _repository.UpdateStoreAsync(store);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _repository.GetStoreByIdAsync(id) == null)
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(string id)
        {
            await _repository.DeleteStoreAsync(id);
            return NoContent();
        }
    }
}
