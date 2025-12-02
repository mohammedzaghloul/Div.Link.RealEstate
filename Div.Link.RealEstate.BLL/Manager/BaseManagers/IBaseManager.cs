using Div.Link.RealEstate.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.BaseManagers
{
    public interface IBaseManager<T> where T:BaseEntity
    {
        public IEnumerable<T> Getall();
        public T GetById(int Id);
        public void Delete(int Id);
        public void Update(T entity);
        public void Add(T entity);
    }
}
