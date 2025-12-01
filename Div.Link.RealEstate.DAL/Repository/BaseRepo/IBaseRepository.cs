using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.DAL.Repository.BaseRepo
{
    public interface IBaseRepository<T>
    {
        public IEnumerable<T> Getall();
        public T GetById(int Id);
        public void Delete(int Id);
        public void Update(T entity);
        public void Add(T entity);
    }
}
