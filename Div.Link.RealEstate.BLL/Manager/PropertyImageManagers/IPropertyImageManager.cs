using Div.Link.RealEstate.BLL.DTO.FavoriteDto;
using Div.Link.RealEstate.BLL.DTO.PropertyImageDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.PropertyImageManagers
{
    public interface IPropertyImageManager
    {
        public IEnumerable<PropertyImageReadDto> Getall();
        public PropertyImageReadDto GetById(int Id);
        public void Delete(int Id);
        public void Update(PropertyImageUpdateDto entity);
        public void Add(PropertyImageCreateDto entity);
    }
}
