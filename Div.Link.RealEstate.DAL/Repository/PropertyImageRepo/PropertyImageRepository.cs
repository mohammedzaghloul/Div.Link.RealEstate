using Div.Link.RealEstate.DAL.Data;
using Div.Link.RealEstate.DAL.Model;
using Div.Link.RealEstate.DAL.Repository.BaseRepo;
namespace Div.Link.RealEstate.DAL.Repository.PropertyImageRepo
{
    public class PropertyImageRepository : BaseRepository<PropertyImage>, IPropertyImageRepository
    {
        public PropertyImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {


        }
    }
}
