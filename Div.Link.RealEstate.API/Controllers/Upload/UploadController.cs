using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Div.Link.RealEstate.BLL.DTO.Account;
using Div.Link.RealEstate.BLL.Manager.CloudinaryService;
using Div.Link.RealEstate.DAL.Data;
using Div.Link.RealEstate.DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Div.Link.RealEstate.API.Controllers.Upload
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
      
            private readonly CloudinaryService _cloudinaryService;
            private readonly ApplicationDbContext _context;
       
        public UploadController(CloudinaryService cloudinaryService, ApplicationDbContext context)
            {
                _cloudinaryService = cloudinaryService;
                _context = context;
            }

            [HttpPost("upload")]
            public async Task<IActionResult> UploadImage([FromForm] UploadImageDto model)
            {
                if (model.ImageFile == null || model.ImageFile.Length == 0)
                    return BadRequest("No image file provided");


                var uploadResult = await _cloudinaryService.UploadImageAsync(model.ImageFile);

                if (uploadResult.Error != null)
                    return BadRequest($"Upload failed: {uploadResult.Error.Message}");

                var propertyImage = new PropertyImage
                {
                    PropertyID = model.PropertyID,
                    ImageUrl = uploadResult.SecureUrl.ToString(),
                    PublicId = uploadResult.PublicId,
                    SortOrder = model.SortOrder
                };

                _context.PropertyImages.Add(propertyImage);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    //imageId = propertyImage.ImageID,
                    url = propertyImage.ImageUrl,
                    sortOrder = propertyImage.SortOrder
                });
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteImage(int id)
            {
                var image = await _context.PropertyImages.FindAsync(id);

                if (image == null)
                    return NotFound();

                if (!string.IsNullOrEmpty(image.PublicId))
                {
                    await _cloudinaryService.DeleteImageAsync(image.PublicId);
                }

                _context.PropertyImages.Remove(image);
                await _context.SaveChangesAsync();

                return Ok();
            }
        }
    }
