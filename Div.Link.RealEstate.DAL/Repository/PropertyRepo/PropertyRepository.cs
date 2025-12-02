using Div.Link.RealEstate.DAL.Data;
using Div.Link.RealEstate.DAL.Model;
using Div.Link.RealEstate.DAL.Model.Div.Link.RealEstate.DAL.Model;
using Div.Link.RealEstate.DAL.Repository.BaseRepo;

namespace Div.Link.RealEstate.DAL.Repository.PropertyRepo
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {


        }
    }
}
