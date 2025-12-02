using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.DTO.PropertyImageDto
{
    public class PropertyImageUpdateDto
    {
        [Required(ErrorMessage = "Id is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Id.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "ImageUrl is required.")]
        [Url(ErrorMessage = "Invalid image URL.")]
        public string ImageUrl { get; set; }

        [Range(0, 999, ErrorMessage = "SortOrder must be between 0 and 999.")]
        public int SortOrder { get; set; }

        public bool IsMain { get; set; }

        [Required(ErrorMessage = "PropertyId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid PropertyId.")]
        public int PropertyId { get; set; }
    }

}
