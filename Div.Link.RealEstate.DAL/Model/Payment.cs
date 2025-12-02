
using Div.Link.RealEstate.DAL.Model.ApplicationUser;
 using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Div.Link.RealEstate.DAL.Model
{
    public class Payment:BaseEntity
    {

        public int PaymentID { get; set; }

      
        public decimal Amount { get; set; }

       
        public string PaymentMethod { get; set; } 

  
        public string TransactionStatus { get; set; } 

        public string TransactionId { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;



        public string UserID { get; set; }

        public int PropertyID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("PropertyID")]
        public virtual Property Property { get; set; }
    }
}