using Div.Link.RealEstate.DAL.Repository.AppointmentRepo;
using Div.Link.RealEstate.DAL.Repository.FavoriteRepo;
using Div.Link.RealEstate.DAL.Repository.PaymentRepo;
using Div.Link.RealEstate.DAL.Repository.PropertyImageRepo;
using Div.Link.RealEstate.DAL.Repository.PropertyRepo;

namespace Div.Link.RealEstate.DAL.Repository.UserRepo
{
    public interface IUnitOfWork
    {
        public IFavoriteRepository FavoriteRepository { get; }
        public IPaymentRepository PaymentRepository { get; }
        public IPropertyRepository PropertyRepository { get; }

        public IAppointmentRepository AppointmentRepository { get; }
        public IPropertyImageRepository PropertyImageRepository { get; }
    

    }
}
