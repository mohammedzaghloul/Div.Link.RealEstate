using Div.Link.RealEstate.BLL.DTO.PropertyDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.DTO.AppointmentDto
{
    public class AppointmentReadDto
    {
        public int Id { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }

        public string BuyerId { get; set; }
        public string SellerId { get; set; }
        public int PropertyId { get; set; }

        public string BuyerName { get; set; }
        public string SellerName { get; set; }

        public PropertyReadDto Property { get; set; }
    }

}
