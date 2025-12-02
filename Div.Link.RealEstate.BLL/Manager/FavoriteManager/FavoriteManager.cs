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


        public FavoriteManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }




    }
}