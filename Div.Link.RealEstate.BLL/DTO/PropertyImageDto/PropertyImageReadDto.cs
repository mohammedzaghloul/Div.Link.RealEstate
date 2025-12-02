using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.DTO.PropertyImageDto
{
    public class PropertyImageReadDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int SortOrder { get; set; }
        public bool IsMain { get; set; }
    }

}
