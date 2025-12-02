using AutoMapper;
using Div.Link.RealEstate.BLL.DTO.FavoriteDto;
using Div.Link.RealEstate.DAL.Data;
using Div.Link.RealEstate.DAL.Model;
using Div.Link.RealEstate.DAL.Repository.UnitOfWork;
using Div.Link.RealEstate.DAL.Repository.UserRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.Manager.FavoriteManager
{


    public class FavoriteManager :  IFavoriteManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public FavoriteManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Add(FavoriteCreateDto entity)
        {
          var ModlDb=  mapper.Map<Favorite>(entity);
            _unitOfWork.FavoriteRepository.Add(ModlDb);
            _unitOfWork.Complete();
        }

        public void Delete(int Id)
        {

            _unitOfWork.FavoriteRepository.Delete(Id);
            _unitOfWork.Complete();

        }

        public IEnumerable<FavoriteReadDto> Getall()
        {
            var AllFavorites = mapper.Map<List<FavoriteReadDto>>(_unitOfWork.FavoriteRepository.Getall().ToList());
            return  AllFavorites;
        }

        public FavoriteReadDto GetById(int Id)
        {
            var ExiteFromDb = _unitOfWork.FavoriteRepository.GetById(Id);
            if (ExiteFromDb == null) return null;
            var OneFavorites = mapper.Map<FavoriteReadDto>(ExiteFromDb);
            return OneFavorites;
        }

        public void Update(FavoriteCreateDto entity)
        {
            var ExiteFromDb = _unitOfWork.FavoriteRepository.GetById(entity.PropertyId);
            if (ExiteFromDb != null)
                mapper.Map(entity, ExiteFromDb);
            _unitOfWork.Complete();
        }
    }
}