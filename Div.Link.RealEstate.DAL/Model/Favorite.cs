
using Div.Link.RealEstate.DAL.Model.ApplicationUsers;
using Div.Link.RealEstate.DAL.Model.ApplicationUsers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Div.Link.RealEstate.DAL.Model
{
    public class Favorite :BaseEntity
    {


        public string UserID { get; set; }


        public int PropertyID { get; set; }

        public DateTime AddedAt { get; set; } = DateTime.UtcNow;

        
        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("PropertyID")]
        public virtual Property Property { get; set; }
    }
}