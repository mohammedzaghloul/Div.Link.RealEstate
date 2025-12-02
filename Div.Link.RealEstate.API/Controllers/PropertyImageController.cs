using Div.Link.RealEstate.BLL.DTO.PropertyImageDto;
using Div.Link.RealEstate.BLL.PropertyImageManagers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Div.Link.RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImageController : ControllerBase
    {
    
            private readonly IPropertyImageManager _manager;

            public PropertyImageController(IPropertyImageManager manager)
            {
                _manager = manager;
            }

            // GET: api/PropertyImage
            [HttpGet]
            public IActionResult GetAll()
            {
                var result = _manager.Getall();
                return Ok(result);
            }

            // GET: api/PropertyImage/5
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var result = _manager.GetById(id);
                if (result == null)
                    return NotFound(new { message = "Image not found." });

                return Ok(result);
            }

            // POST: api/PropertyImage
            [HttpPost]
            public IActionResult Create([FromBody] PropertyImageCreateDto dto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _manager.Add(dto);
                return Ok(new { message = "Image created successfully." });
            }

        // PUT: api/PropertyImage
        [HttpPut]
        public IActionResult Update([FromBody] PropertyImageUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _manager.Update(dto);
                return Ok(new { message = "Image updated successfully." });
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
                return Ok(new { message = "Image deleted successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}