
using AutoMapper;
using Div.Link.RealEstate.BLL.DTO.PropertyImageDto;
using Div.Link.RealEstate.BLL.DTO.PropertyImageDto;
using Div.Link.RealEstate.DAL.Model;
using Div.Link.RealEstate.DAL.Repository.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.PropertyImageManagers
{
    public class PropertyImageManager : IPropertyImageManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public PropertyImageManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Add(PropertyImageCreateDto entity)
        {
            var ModlDb = mapper.Map<PropertyImage>(entity);
            _unitOfWork.PropertyImageRepository.Add(ModlDb);
            _unitOfWork.Complete();
        }

        public void Delete(int Id)
        {

            _unitOfWork.PropertyImageRepository.Delete(Id);
            _unitOfWork.Complete();

        }

        public IEnumerable<PropertyImageReadDto> Getall()
        {
            var AllPropertyImages = mapper.Map<List<PropertyImageReadDto>>(_unitOfWork.PropertyImageRepository.Getall().ToList());
            return AllPropertyImages;
        }

        public PropertyImageReadDto GetById(int Id)
        {
            var ExiteFromDb = _unitOfWork.PropertyImageRepository.GetById(Id);
            if (ExiteFromDb == null) return null;
            var OnePropertyImages = mapper.Map<PropertyImageReadDto>(ExiteFromDb);
            return OnePropertyImages;
        }

        public void Update(PropertyImageUpdateDto entity)
        {
            var ExiteFromDb = _unitOfWork.PropertyImageRepository.GetById(entity.Id);
            if (ExiteFromDb != null)
                mapper.Map(entity, ExiteFromDb);
            _unitOfWork.Complete();
        }
    }
}
