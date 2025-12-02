using Div.Link.RealEstate.BLL.BaseManagers;
using Div.Link.RealEstate.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.PaymentManagers
{
    public class PaymentManagers<T> : IBaseManager<Payment> where T : BaseEntity
    {
        public void Add(Payment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Payment> Getall()
        {
            throw new NotImplementedException();
        }

        public Payment GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Payment entity)
        {
            throw new NotImplementedException();
        }
    }
}
