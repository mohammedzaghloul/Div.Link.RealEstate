
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.DAL.Model.ApplicationUsers
{

    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfileImage { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public virtual ICollection<Property>? OwnedProperties { get; set; }
        public virtual ICollection<Favorite>? FavoriteProperties { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
        public virtual ICollection<Appointment>? BuyerAppointments { get; set; }
        public virtual ICollection<Appointment>? SellerAppointments { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}

