using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class QuotationProfile : Profile
    {
        public QuotationProfile()
        {
            CreateMap<Quotation, QuotationDto>()
                .ForMember(dest => dest.DealerName, opt => opt.MapFrom(src => src.Dealer.Name))
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(
                    dest => dest.CustomerFullName,
                    opt => opt.MapFrom(src => src.Customer.FullName)
                )
                .ForMember(dest => dest.VariantName, opt => opt.MapFrom(src => src.Variant.Name));
            CreateMap<CreateQuotationDto, Quotation>(MemberList.Source);
            CreateMap<UpdateQuotationDto, Quotation>(MemberList.Source);
            CreateMap<PatchQuotationDto, Quotation>(MemberList.Source)
                .ForAllMembers(opts =>
                    opts.Condition(
                        (src, dest, srcMember, context) =>
                            srcMember != null
                            && !(srcMember is Guid guid && guid == Guid.Empty)
                            && !(srcMember is DateTime dt && dt == default)
                    )
                );
        }
    }
}
