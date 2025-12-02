using Div.Link.RealEstate.BLL.DTO.FavoriteDto;
using Div.Link.RealEstate.BLL.Manager.FavoriteManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Div.Link.RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteManager _manager;

        public FavoriteController(IFavoriteManager manager)
        {
            _manager = manager;
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetUserFavorites(int userId)
            => Ok(_manager.GetById(userId));

        [HttpPost]
        public IActionResult AddToFavorite(FavoriteCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _manager.Add(dto);
            return Ok(new { message = "Added to favorites." });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _manager.Delete(id);
                return Ok(new { message = "Favorite removed successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
