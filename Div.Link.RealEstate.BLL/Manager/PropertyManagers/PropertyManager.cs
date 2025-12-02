using Div.Link.RealEstate.BLL.BaseManagers;
using Div.Link.RealEstate.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.Manager.PropertyManagers
{
    public class PropertyManager<T> : BaseManager<Property> where T : BaseEntity,IPropertyManager
    {
       
    }
}
