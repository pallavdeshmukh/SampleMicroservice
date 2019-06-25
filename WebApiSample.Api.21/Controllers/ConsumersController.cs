using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.DataAccess.Models;
using WebApiSample.DataAccess.Repositories;

namespace WebApiSample.Api._21.Controllers
{
    #region snippet_ConsumersController
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ConsumersController : MyApiControllerBase
    {
        private readonly ConsumersRepository _repository;

        public ConsumersController(ConsumersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Consumer>>> GetAllAsync()
        {
            return await _repository.GetConsumersAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Consumer>> GetByIdAsync(int id)
        {
            var Consumer = await _repository.GetConsumerAsync(id);

            if (Consumer == null)
            {
                return NotFound();
            }

            return Consumer;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Consumer>> CreateAsync(Consumer Consumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddConsumerAsync(Consumer);

            return CreatedAtAction(nameof(GetByIdAsync),
                new { id = Consumer.Id }, Consumer);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> DeleteByIdAsync(int id)
        {
            var rowsAffected = await _repository.DeleteConsumerAsync(id);

            if (rowsAffected == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
    #endregion
}
