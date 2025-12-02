using Div.Link.RealEstate.DAL.Data;
using Div.Link.RealEstate.DAL.Repository.AppointmentRepo;
using Div.Link.RealEstate.DAL.Repository.FavoriteRepo;
using Div.Link.RealEstate.DAL.Repository.PaymentRepo;
using Div.Link.RealEstate.DAL.Repository.PropertyImageRepo;
using Div.Link.RealEstate.DAL.Repository.PropertyRepo;
using Div.Link.RealEstate.DAL.Repository.UserRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.DAL.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
  

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            
        }
        private IFavoriteRepository? _favoriteRepository;
        private IPaymentRepository? _paymentRepository;
        private IPropertyRepository? _propertyRepository;
        private IAppointmentRepository? _appointmentRepository;
        private IPropertyImageRepository? _propertyImageRepository;
        private readonly ApplicationDbContext dbContext;

        public IFavoriteRepository FavoriteRepository => _favoriteRepository  ??= new FavoriteRepository(dbContext);
        public IPropertyRepository PropertyRepository => _propertyRepository ??= new PropertyRepository(dbContext);

        public IPaymentRepository PaymentRepository => _paymentRepository ??= new PaymentRepository(dbContext);

        public IAppointmentRepository AppointmentRepository => _appointmentRepository ??= new AppointmentRepository(dbContext);

        public IPropertyImageRepository PropertyImageRepository => _propertyImageRepository??= new PropertyImageRepository(dbContext);

        public int Complete()
        {
         return   dbContext.SaveChanges();
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
