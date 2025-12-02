using Div.Link.RealEstate.BLL.DTO.AppointmentDto;
using Div.Link.RealEstate.BLL.Manager.AppointmentManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Div.Link.RealEstate.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentManager _manager;

        public AppointmentController(IAppointmentManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAll()
            => Ok(_manager.Getall());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _manager.GetById(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(AppointmentCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _manager.Add(dto);
            return Ok(new { message = "Appointment created successfully." });
        }

        [HttpPut]
        public IActionResult Update(AppointmentUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _manager.Update(dto);
                return Ok(new { message = "Appointment updated successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _manager.Delete(id);
                return Ok(new { message = "Appointment deleted successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
