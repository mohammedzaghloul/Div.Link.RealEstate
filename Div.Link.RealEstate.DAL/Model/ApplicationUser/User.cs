using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.DAL.Model.ApplicationUser
{
    using global::Div.Link.RealEstate.DAL.Model.Div.Link.RealEstate.DAL.Model;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    namespace Div.Link.RealEstate.DAL.Model.ApplicationUser
    {
        public class User : IdentityUser
        {
            // الخصائص الأساسية
            public string FirstName { get; set; }
            public string LastName { get; set; }

            // الخصائص الإضافية
            public string ProfileImage { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Address { get; set; }

            // علاقة واحدة إلى كثير: User -> Properties (العقارات التي يملكها/يعرضها)
            public virtual ICollection<Property> OwnedProperties { get; set; }

            // علاقة واحدة إلى كثير: User -> Favorites (العقارات المفضلة)
            public virtual ICollection<Favorite> FavoriteProperties { get; set; }

            // علاقة واحدة إلى كثير: User -> Payments (المدفوعات التي أجراها)
            public virtual ICollection<Payment> Payments { get; set; }

            // علاقة واحدة إلى كثير: User -> Appointments (المواعيد التي حجزها كمشتري)
            public virtual ICollection<Appointment> BuyerAppointments { get; set; }

            // علاقة واحدة إلى كثير: User -> Appointments (المواعيد التي لديه كبائع)
            public virtual ICollection<Appointment> SellerAppointments { get; set; }

            // طرق مساعدة
            public string FullName => $"{FirstName} {LastName}";
        }
    }
}
