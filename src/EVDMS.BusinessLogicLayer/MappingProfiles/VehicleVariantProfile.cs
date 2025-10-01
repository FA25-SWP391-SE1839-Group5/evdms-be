using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.Common.Helpers;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class VehicleVariantProfile : Profile
    {
        public VehicleVariantProfile()
        {
            CreateMap<VehicleVariant, VehicleVariantDto>()
                .ForMember(dest => dest.Specs, opt => opt.MapFrom(src => src.SpecsObject))
                .ForMember(dest => dest.Features, opt => opt.MapFrom(src => src.FeaturesObject));

            CreateMap<CreateVehicleVariantDto, VehicleVariant>(MemberList.Source)
                .ForMember(dest => dest.Specs, opt => opt.MapFrom(src => SerializeSpecs(src.Specs)))
                .ForMember(
                    dest => dest.Features,
                    opt => opt.MapFrom(src => SerializeFeatures(src.Features))
                );

            CreateMap<UpdateVehicleVariantDto, VehicleVariant>(MemberList.Source)
                .ForMember(dest => dest.Specs, opt => opt.MapFrom(src => SerializeSpecs(src.Specs)))
                .ForMember(
                    dest => dest.Features,
                    opt => opt.MapFrom(src => SerializeFeatures(src.Features))
                );

            CreateMap<PatchVehicleVariantDto, VehicleVariant>(MemberList.Source)
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }

        private static readonly System.Text.Json.JsonSerializerOptions IgnoreNullOptions = new()
        {
            DefaultIgnoreCondition = System
                .Text
                .Json
                .Serialization
                .JsonIgnoreCondition
                .WhenWritingNull,
        };

        private static string SerializeSpecs(VehicleSpecs specs) =>
            System.Text.Json.JsonSerializer.Serialize(specs, IgnoreNullOptions);

        private static string SerializeFeatures(VehicleFeatures features) =>
            System.Text.Json.JsonSerializer.Serialize(features, IgnoreNullOptions);
    }
}
