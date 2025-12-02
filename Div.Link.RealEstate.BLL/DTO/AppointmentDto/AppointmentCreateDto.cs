using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.DTO.AppointmentDto
{
    public class AppointmentCreateDto
    {
        public DateTime AppointmentDateTime { get; set; }
        public string BuyerId { get; set; }
        public string SellerId { get; set; }
        public int PropertyId { get; set; }
        public string? Notes { get; set; }
    }

}
