using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.DTO.PaymentDto
{
    public class PaymentCreateDto
    {
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string UserId { get; set; }
        public int PropertyId { get; set; }
    }

}
