using Div.Link.RealEstate.DAL.Model.ApplicationUser;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Div.Link.RealEstate.DAL.Model
{
    public class Appointment:BaseEntity
    {
       
        public int AppointmentID { get; set; }

        public DateTime AppointmentDateTime { get; set; }


        public string Status { get; set; } 

        public string Notes { get; set; }

        public string BuyerID { get; set; } 

        public string SellerID { get; set; }


        public int PropertyID { get; set; }

        [ForeignKey("BuyerID")]
        public virtual User Buyer { get; set; }

        [ForeignKey("SellerID")]
        public virtual User Seller { get; set; }

        [ForeignKey("PropertyID")]
        public virtual Property Property { get; set; }
    }
}