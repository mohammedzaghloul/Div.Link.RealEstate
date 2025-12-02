using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.DTO.PaymentDto
{
    public class PaymentReadDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionStatus { get; set; }
        public string TransactionId { get; set; }
        public DateTime PaymentDate { get; set; }

        public int PropertyId { get; set; }
        public string UserId { get; set; }
    }

}
