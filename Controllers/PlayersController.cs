using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BasketballCrudAPI.Data.Models;
using BasketballCrudAPI.Data.Services;
namespace BasketballCrudAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PlayerService _playerService;
        public PlayersController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public ActionResult<List<Player>> GetRoster()
        {
            return _playerService.GetRoster();
        }

        [HttpGet("{id:length(24)}", Name = "GetPlayer")]
        public ActionResult<Player> GetPlayer(string id)
        {
            return _playerService.GetPlayer(id);
        }


        [HttpPost]
        public ActionResult<Player> Create([FromBody] Player player)
        {
            _playerService.AddPlayer(player);

            return CreatedAtRoute("GetPlayer", new { id = player.Id.ToString() }, player);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, [FromBody] Player playerIn)
        {
            var player = _playerService.GetPlayer(id);

            if (player == null)
            {
                return NotFound();
            }

            _playerService.Update(id, playerIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var player = _playerService.GetPlayer(id);

            if (player == null)
            {
                return NotFound();
            }

            _playerService.Remove(player.Id);

            return NoContent();
        }
    }
}
