using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pubs1.Models;
using pubs1.Services.Interface;

namespace pubs1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        // GET: api/store
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Store>>> GetStores()
        {
            var stores = await _storeService.GetAllStoresAsync();
            return Ok(stores);
        }

        // GET: api/store/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> GetStore(string id)
        {
            var store = await _storeService.GetStoreByIdAsync(id);

            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }

        // POST: api/store
        [HttpPost]
        public async Task<ActionResult<Store>> AddStore([FromBody] Store newStore)
        {
            var createdStore = await _storeService.AddStoreAsync(newStore);
            return CreatedAtAction(nameof(GetStore), new { id = createdStore.StorId }, createdStore);
        }

        // PUT: api/store/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStore(string id, [FromBody] Store updatedStore)
        {
            var store = await _storeService.UpdateStoreAsync(id, updatedStore);
            if (store == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/store/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(string id)
        {
            var success = await _storeService.DeleteStoreAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
