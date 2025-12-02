using Div.Link.RealEstate.BLL.DTO.PaymentDto;
using Div.Link.RealEstate.BLL.PaymentManagers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Div.Link.RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentManager _manager;

        public PaymentController(IPaymentManager manager)
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
        public IActionResult Create(PaymentCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _manager.Add(dto);
            return Ok(new { message = "Payment recorded successfully." });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _manager.Delete(id);
                return Ok(new { message = "Payment deleted successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
