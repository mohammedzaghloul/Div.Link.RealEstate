using Div.Link.RealEstate.BLL.DTO.FavoriteDto;
using Div.Link.RealEstate.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.Manager.FavoriteManager
{
    public interface IFavoriteManager
    {
        public IEnumerable<FavoriteReadDto> Getall();
        public FavoriteReadDto GetById(int Id);
        public void Delete(int Id);
        public void Update(FavoriteCreateDto entity);
        public void Add(FavoriteCreateDto entity);
    }
}
