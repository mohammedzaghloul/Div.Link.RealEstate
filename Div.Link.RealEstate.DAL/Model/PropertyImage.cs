
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Div.Link.RealEstate.DAL.Model
{
    public class PropertyImage:BaseEntity
    {
        public string ImageUrl { get; set; }

        public string PublicId { get; set; } 

        public int SortOrder { get; set; } = 0;

        public bool IsMain { get; set; } = false;

  
        public int PropertyID { get; set; }

        [ForeignKey("PropertyID")]
        public virtual Property Property { get; set; }
    }
}