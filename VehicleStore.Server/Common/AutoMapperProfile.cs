using AutoMapper;
using AutoMapper.Features;
using System;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.Entities;
using VehicleStore.Server.Models.RequestModels.VehicleModelRequestModels;
using VehicleStore.Server.Models.RequestModels.VehicleRequestModels;
using VehicleStore.Server.Models.ResponseModels.VehicleModelResponseModels;
using VehicleStore.Server.Models.ResponseModels.VehicleResponseModels;

namespace VehicleStore.Server.Common
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            // Vehicle
            CreateMap<Vehicle, VehicleResponseModel>();
            CreateMap<VehicleModel, VehicleResponseModel>()
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Name));
            CreateMap<CreateVehicleRequestModel, Vehicle>();

            // VehicleModel
            CreateMap<VehicleModel, VehicleModelResponseModel>();
            CreateMap<CreateVehicleModelRequestModel, VehicleModel>();
        }

    }
}
