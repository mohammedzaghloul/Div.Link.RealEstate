using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.DTO.AppointmentDto
{

    public class AppointmentUpdateDto
    {
        [Required(ErrorMessage = "Id is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid appointment Id.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Appointment date is required.")]
        public DateTime AppointmentDateTime { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(50, ErrorMessage = "Status must not exceed 50 characters.")]
        public string Status { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "BuyerId is required.")]
        public string BuyerId { get; set; }

        [Required(ErrorMessage = "SellerId is required.")]
        public string SellerId { get; set; }

        [Required(ErrorMessage = "PropertyId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Property Id.")]
        public int PropertyId { get; set; }
    }
}
