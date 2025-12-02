
using Div.Link.RealEstate.DAL.Model.ApplicationUser;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Div.Link.RealEstate.DAL.Model
{
    public class Favorite :BaseEntity
    {

        public int FavoriteID { get; set; }


        public string UserID { get; set; }


        public int PropertyID { get; set; }

        public DateTime AddedAt { get; set; } = DateTime.UtcNow;

        
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("PropertyID")]
        public virtual Property Property { get; set; }
    }
}