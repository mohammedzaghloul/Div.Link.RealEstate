using AutoMapper;
using Div.Link.RealEstate.BLL.DTO.AppointmentDto;
using Div.Link.RealEstate.DAL.Model;
using Div.Link.RealEstate.DAL.Repository.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.Manager.AppointmentManager
{
    public class AppointmentManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public AppointmentManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Add(AppointmentCreateDto entity)
        {
            var ModlDb = mapper.Map<Appointment>(entity);
            _unitOfWork.AppointmentRepository.Add(ModlDb);
            _unitOfWork.Complete();
        }

        public void Delete(int Id)
        {

            _unitOfWork.AppointmentRepository.Delete(Id);
            _unitOfWork.Complete();

        }

        public IEnumerable<AppointmentReadDto> Getall()
        {
            var AllAppointments = mapper.Map<List<AppointmentReadDto>>(_unitOfWork.AppointmentRepository.Getall().ToList());
            return AllAppointments;
        }

        public AppointmentReadDto GetById(int Id)
        {
            var ExiteFromDb = _unitOfWork.AppointmentRepository.GetById(Id);
            if (ExiteFromDb == null) return null;
            var OneAppointments = mapper.Map<AppointmentReadDto>(ExiteFromDb);
            return OneAppointments;
        }

        public void Update(AppointmentUpdateDto entity)
        {
            var ExiteFromDb = _unitOfWork.AppointmentRepository.GetById(entity.PropertyId);
            if (ExiteFromDb != null)
                mapper.Map(entity, ExiteFromDb);
            _unitOfWork.Complete();
        }
    }
}
