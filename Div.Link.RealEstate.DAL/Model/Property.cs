using Div.Link.RealEstate.DAL.Model.ApplicationUser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.DAL.Model
{
    using global::Div.Link.RealEstate.DAL.Model.ApplicationUser.Div.Link.RealEstate.DAL.Model.ApplicationUser;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace Div.Link.RealEstate.DAL.Model
    {
        public class Property  : BaseEntity 
        {
  
            public int PropertyID { get; set; }
            public string Title { get; set; }

   
            public string Description { get; set; }

            public decimal Price { get; set; }

            public string AreaSqm { get; set; }
            public int NumberOfRooms { get; set; }

     
            public string PropertyType { get; set; }

            public string Address { get; set; }

            public decimal Latitude { get; set; }

     
            public decimal Longitude { get; set; }

            public string Status { get; set; } 
            public string SellerID { get; set; }
            [ForeignKey("SellerID")]
            public virtual User Seller { get; set; }

            public virtual ICollection<PropertyImage> Images { get; set; }
            public virtual ICollection<Favorite> Favorites { get; set; }
            public virtual ICollection<Payment> Payments { get; set; }
            public virtual ICollection<Appointment> Appointments { get; set; }

            public string FormattedPrice => Price.ToString("C");
            public string Location => $"{Latitude}, {Longitude}";
        }
    }
}
