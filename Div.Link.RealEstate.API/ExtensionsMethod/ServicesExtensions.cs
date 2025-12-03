using CloudinaryDotNet;
using Div.Link.RealEstate.BLL.AutoMapper;
using Div.Link.RealEstate.BLL.Manager.AppointmentManager;
using Div.Link.RealEstate.BLL.Manager.CloudinaryService;
using Div.Link.RealEstate.BLL.Manager.FavoriteManager;
using Div.Link.RealEstate.BLL.Manager.PropertyManagers;
using Div.Link.RealEstate.BLL.PaymentManagers;
using Div.Link.RealEstate.BLL.PropertyImageManagers;
using Div.Link.RealEstate.DAL.Data;
using Div.Link.RealEstate.DAL.Model.ApplicationUsers;
using Div.Link.RealEstate.DAL.Model;
using Div.Link.RealEstate.DAL.Repository.BaseRepo;
using Div.Link.RealEstate.DAL.Repository.UnitOfWork;
using Div.Link.RealEstate.DAL.Repository.UserRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Div.Link.RealEstate.API.ExtensionsMethod
{
    public static class ServicesExtensions
    {
      public static IServiceCollection AddServices(this IServiceCollection services,IConfiguration configuration)
        {
          services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .UseLazyLoadingProxies();
            });

            #region Add Services
            // ============ Add Services ============
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IAppointmentManager, AppointmentManager>();
            services.AddScoped<IPropertyImageManager, PropertyImageManager>();
            services.AddScoped<IPropertyManager, PropertyManager>();
            services.AddScoped<IFavoriteManager, FavoriteManager>();
            services.AddScoped<IPaymentManager, PaymentManager>(); 
            #endregion

            #region Identity
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
            })
          .AddEntityFrameworkStores<ApplicationDbContext>()
          .AddDefaultTokenProviders();
            #endregion

            #region Policy
            // ============ CORS Policy ============
           services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
            #endregion

            #region cloudinaryAccount
            var cloudinaryAccount = new Account(
                 configuration["Cloudinary:CloudName"],
                 configuration["Cloudinary:ApiKey"],
                 configuration["Cloudinary:ApiSecret"]
             );
           services.Configure<CloudinarySettings>(
           configuration.GetSection("Cloudinary"));

            services.AddScoped<CloudinaryService>();
            #endregion

            #region Authentication

            // ============ JWT Authentication ============
            var secretKey = configuration["JWT:SecretKey"];

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };
            });
            #endregion

            #region Swagger Configuration 

            // ============ Swagger Configuration ============
           services.AddEndpointsApiExplorer();
           services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET 8 Web API",
                    Description = "ITI Project",
                    Contact = new OpenApiContact
                    {
                        Name = "Mohammed Zaghloul",
                        Email = "mohammedzaghloul0123@gmail.com"
                    }
                });

                // ?? JWT Support in Swagger
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' followed by your token.\nExample: 'Bearer 12345abcdef'"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

                //options.EnableAnnotations();
            });

            #endregion

            return services;
        }
    }
}
