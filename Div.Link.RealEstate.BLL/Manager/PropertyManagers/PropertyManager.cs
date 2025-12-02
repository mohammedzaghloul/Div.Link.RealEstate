using Div.Link.RealEstate.BLL.BaseManagers;
using Div.Link.RealEstate.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.Manager.PropertyManagers
{
    public class PropertyManager<T> : IBaseManager<Property> where T : BaseEntity,IPropertyManager
    {
        public void Add(Property entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Property> Getall()
        {
            throw new NotImplementedException();
        }

        public Property GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Property entity)
        {
            throw new NotImplementedException();
        }
    }
}
