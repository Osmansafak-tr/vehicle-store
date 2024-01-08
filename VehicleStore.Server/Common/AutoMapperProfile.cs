using AutoMapper;
using VehicleStore.Server.Models.Entities;
using VehicleStore.Server.Models.RequestModels.UserRequestModels;
using VehicleStore.Server.Models.RequestModels.VehicleRequestModels;
using VehicleStore.Server.Models.ResponseModels.UserResponseModels;
using VehicleStore.Server.Models.ResponseModels.VehicleModelResponseModels;
using VehicleStore.Server.Models.ResponseModels.VehicleResponseModels;

namespace VehicleStore.Server.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Vehicle
            CreateMap<Vehicle, VehicleResponseModel>();
            CreateMap<CreateVehicleRequestModel, Vehicle>();

            // VehicleModel
            CreateMap<VehicleModel, VehicleModelResponseModel>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => Convert.ToBase64String(src.Image)));

            // User
            CreateMap<User, UserResponseModel>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToString("dd/MM/yyyy")));
            CreateMap<CreateUserRequestModel, User>();
        }
    }
}