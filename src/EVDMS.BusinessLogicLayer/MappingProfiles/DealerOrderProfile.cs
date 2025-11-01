using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class DealerOrderProfile : Profile
    {
        public DealerOrderProfile()
        {
            CreateMap<DealerOrder, DealerOrderDto>()
                .ForMember(dest => dest.DealerName, opt => opt.MapFrom(src => src.Dealer.Name))
                .ForMember(
                    dest => dest.VariantName,
                    opt => opt.MapFrom(src => src.VehicleVariant.Name)
                );

            CreateMap<CreateDealerOrderDto, DealerOrder>(MemberList.Source)
                .ForMember(dest => dest.DealerId, opt => opt.Ignore());
            CreateMap<UpdateDealerOrderDto, DealerOrder>(MemberList.Source);
            CreateMap<PatchDealerOrderDto, DealerOrder>(MemberList.Source)
                .ForAllMembers(opts =>
                    opts.Condition(
                        (src, dest, srcMember, context) =>
                            opts.DestinationMember.Name == nameof(DealerOrder.Color)
                                ? (src.Color.HasValue)
                            : opts.DestinationMember.Name == nameof(DealerOrder.Quantity)
                                ? (src.Quantity.HasValue)
                            : srcMember != null
                                && !(srcMember is Guid guid && guid == Guid.Empty)
                                && !(srcMember is DateTime dt && dt == default)
                    )
                );

            CreateMap<DealerOrder, VariantOrderRateDto>()
                .ForMember(dest => dest.VariantId, opt => opt.MapFrom(src => src.VariantId))
                .ForMember(
                    dest => dest.VariantName,
                    opt => opt.MapFrom(src => src.VehicleVariant.Name)
                );
        }
    }
}
