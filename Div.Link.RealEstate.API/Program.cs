using CloudinaryDotNet;
using Div.Link.RealEstate.BLL.AutoMapper;
using Div.Link.RealEstate.BLL.Manager.CloudinaryService;
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

            // ============ Database Connection ============
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .UseLazyLoadingProxies();
            });
            #region AddServices
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            #endregion

            #region Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
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
            builder.Services.AddCors(options =>
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
                 builder.Configuration["Cloudinary:CloudName"],
                 builder.Configuration["Cloudinary:ApiKey"],
                 builder.Configuration["Cloudinary:ApiSecret"]
             );
            builder.Services.Configure<CloudinarySettings>(
            builder.Configuration.GetSection("Cloudinary"));

            builder.Services.AddScoped<CloudinaryService>();
            #endregion

            #region Authentication

            // ============ JWT Authentication ============
            var secretKey = builder.Configuration["JWT:SecritKey"];

            builder.Services.AddAuthentication(options =>
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
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
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

 
            var app = builder.Build();

            // ============ Middleware ============
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
        }
    }
}
