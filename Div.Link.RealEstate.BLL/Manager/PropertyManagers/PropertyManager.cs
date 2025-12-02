
using AutoMapper;
using Div.Link.RealEstate.BLL.DTO.PropertyDto;
using Div.Link.RealEstate.BLL.DTO.PropertyDto;
using Div.Link.RealEstate.DAL.Model;
using Div.Link.RealEstate.DAL.Repository.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.Manager.PropertyManagers
{
    public class PropertyManager : IPropertyManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public PropertyManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Add(PropertyCreateDto entity)
        {
            var ModlDb = mapper.Map<Property>(entity);
            _unitOfWork.PropertyRepository.Add(ModlDb);
            _unitOfWork.Complete();
        }

        public void Delete(int Id)
        {

            _unitOfWork.PropertyRepository.Delete(Id);
            _unitOfWork.Complete();

        }

        public IEnumerable<PropertyReadDto> Getall()
        {
            var AllPropertys = mapper.Map<List<PropertyReadDto>>(_unitOfWork.PropertyRepository.Getall().ToList());
            return AllPropertys;
        }

        public PropertyReadDto GetById(int Id)
        {
            var ExiteFromDb = _unitOfWork.PropertyRepository.GetById(Id);
            if (ExiteFromDb == null) return null;
            var OnePropertys = mapper.Map<PropertyReadDto>(ExiteFromDb);
            return OnePropertys;
        }

        public void Update(PropertyUpdateDto entity)
        {
            var ExiteFromDb = _unitOfWork.PropertyRepository.GetById(entity.Id);
            if (ExiteFromDb != null)
                mapper.Map(entity, ExiteFromDb);
            _unitOfWork.Complete();
        }
    }
}
