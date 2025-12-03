using CloudinaryDotNet;
using Div.Link.RealEstate.API.ExtensionsMethod;
using Div.Link.RealEstate.BLL.AutoMapper;
using Div.Link.RealEstate.BLL.Manager.AppointmentManager;
using Div.Link.RealEstate.BLL.Manager.CloudinaryService;
using Div.Link.RealEstate.BLL.Manager.FavoriteManager;
using Div.Link.RealEstate.BLL.Manager.PropertyManagers;
using Div.Link.RealEstate.BLL.PaymentManagers;
using Div.Link.RealEstate.BLL.PropertyImageManagers;
using Div.Link.RealEstate.DAL.Data;
using Div.Link.RealEstate.DAL.Model;
using Div.Link.RealEstate.DAL.Model.ApplicationUsers;
using Div.Link.RealEstate.DAL.Repository.BaseRepo;
using Div.Link.RealEstate.DAL.Repository.UnitOfWork;
using Div.Link.RealEstate.DAL.Repository.UserRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Runtime.Serialization;
using System.Text;

namespace Div.Link.RealEstate.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
            builder.Services.AddServices(builder.Configuration);
            #region Middleware
            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run(); 
            #endregion
        }
    }
}
