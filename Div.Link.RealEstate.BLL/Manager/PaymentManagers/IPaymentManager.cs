using Div.Link.RealEstate.BLL.DTO.FavoriteDto;
using Div.Link.RealEstate.BLL.DTO.PaymentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.PaymentManagers
{
    public interface IPaymentManager
    {
        public IEnumerable<PaymentReadDto> Getall();
        public PaymentReadDto GetById(int Id);
        public void Delete(int Id);
        public void Update(PaymentCreateDto entity);
        public void Add(PaymentCreateDto entity);
    }
}
