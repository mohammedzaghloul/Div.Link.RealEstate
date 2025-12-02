using Div.Link.RealEstate.BLL.DTO.PropertyDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.DTO.FavoriteDto
{
    public class FavoriteReadDto
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public DateTime AddedAt { get; set; }

        public PropertyReadDto Property { get; set; }
    }

}
