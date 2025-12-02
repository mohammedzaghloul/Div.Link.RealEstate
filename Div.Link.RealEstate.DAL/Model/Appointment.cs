using Div.Link.RealEstate.DAL.Model.ApplicationUsers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Div.Link.RealEstate.DAL.Model
{
    public class Appointment : BaseEntity
    {
        public DateTime AppointmentDateTime { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }

        public string BuyerID { get; set; }
        public string SellerID { get; set; }
        public int PropertyID { get; set; }

        [ForeignKey("BuyerID")]
        public virtual ApplicationUser Buyer { get; set; }

        [ForeignKey("SellerID")]
        public virtual ApplicationUser Seller { get; set; }

        [ForeignKey("PropertyID")]
        public virtual Property Property { get; set; }
    }

}