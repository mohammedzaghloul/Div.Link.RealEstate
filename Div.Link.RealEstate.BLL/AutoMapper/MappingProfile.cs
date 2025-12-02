using AutoMapper;
using Div.Link.RealEstate.BLL.DTO;
using Div.Link.RealEstate.BLL.DTO.Account;
using Div.Link.RealEstate.BLL.DTO.AppointmentDto;
using Div.Link.RealEstate.BLL.DTO.FavoriteDto;
using Div.Link.RealEstate.BLL.DTO.PaymentDto;
using Div.Link.RealEstate.BLL.DTO.PropertyDto;
using Div.Link.RealEstate.BLL.DTO.PropertyImageDto;
using Div.Link.RealEstate.BLL.DTO.UserDto;
using Div.Link.RealEstate.DAL.Model;
using Div.Link.RealEstate.DAL.Model.ApplicationUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.BLL.AutoMapper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserReadDto>().ReverseMap();
            CreateMap<UserCreateDto, ApplicationUser>();
            CreateMap<UserUpdateDto, ApplicationUser>();

            // Property
            CreateMap<Property, PropertyReadDto>()
                .ForMember(dest => dest.SellerName,
                           opt => opt.MapFrom(src => src.Seller.FirstName + " " + src.Seller.LastName));
            CreateMap<PropertyCreateDto, Property>();
            CreateMap<PropertyUpdateDto, Property>();

            // PropertyImage
            CreateMap<PropertyImage, PropertyImageReadDto>().ReverseMap();
            CreateMap<PropertyImageCreateDto, PropertyImage>();

            // Favorite
            CreateMap<Favorite, FavoriteReadDto>().ReverseMap();
            CreateMap<FavoriteCreateDto, Favorite>();

            // Payment
            CreateMap<Payment, PaymentReadDto>().ReverseMap();
            CreateMap<PaymentCreateDto, Payment>();

            // Appointment
            CreateMap<Appointment, AppointmentReadDto>()
                .ForMember(dest => dest.BuyerName,
                           opt => opt.MapFrom(src => src.Buyer.FirstName + " " + src.Buyer.LastName))
                .ForMember(dest => dest.SellerName,
                           opt => opt.MapFrom(src => src.Seller.FirstName + " " + src.Seller.LastName));

            CreateMap<AppointmentCreateDto, Appointment>();
        }
    }
}
