
using AutoMapper;
using Div.Link.RealEstate.BLL.DTO.PaymentDto;
using Div.Link.RealEstate.BLL.DTO.PaymentDto;
using Div.Link.RealEstate.DAL.Model;
using Div.Link.RealEstate.DAL.Repository.PaymentRepo;
using Div.Link.RealEstate.DAL.Repository.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.PaymentManagers
{
    public class PaymentManager : IPaymentManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public PaymentManager(IUnitOfWork unitOfWork ,IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Add(PaymentCreateDto entity)
        {
            var ModlDb = mapper.Map<Payment>(entity);
            _unitOfWork.PaymentRepository.Add(ModlDb);
            _unitOfWork.Complete();
        }

        public void Delete(int Id)
        {

            _unitOfWork.PaymentRepository.Delete(Id);
            _unitOfWork.Complete();

        }

        public IEnumerable<PaymentReadDto> Getall()
        {
            var AllPayments = mapper.Map<List<PaymentReadDto>>(_unitOfWork.PaymentRepository.Getall().ToList());
            return AllPayments;
        }

        public PaymentReadDto GetById(int Id)
        {
            var ExiteFromDb = _unitOfWork.PaymentRepository.GetById(Id);
            if (ExiteFromDb == null) return null;
            var OnePayments = mapper.Map<PaymentReadDto>(ExiteFromDb);
            return OnePayments;
        }

        public void Update(PaymentCreateDto entity)
        {
            var ExiteFromDb = _unitOfWork.PaymentRepository.GetById(entity.PropertyId);
            if (ExiteFromDb != null)
                mapper.Map(entity, ExiteFromDb);
            _unitOfWork.Complete();
        }
    }
}
