using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.DTO.Account
{
    public class UploadImageDto
    {
        public int PropertyID { get; set; }
        public IFormFile ImageFile { get; set; }
        public int SortOrder { get; set; }
    }
}
