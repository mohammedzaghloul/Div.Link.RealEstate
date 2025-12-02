using Div.Link.RealEstate.BLL.DTO.FavoriteDto;
using Div.Link.RealEstate.BLL.DTO.PropertyDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.Manager.PropertyManagers
{
    public interface IPropertyManager
    {
        public IEnumerable<PropertyReadDto> Getall();
        public PropertyReadDto GetById(int Id);
        public void Delete(int Id);
        public void Update(PropertyUpdateDto entity);
        public void Add(PropertyCreateDto entity);
    }
}
