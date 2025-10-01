using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class QuotationProfile : Profile
    {
        public QuotationProfile()
        {
            CreateMap<Quotation, QuotationDto>();
            CreateMap<CreateQuotationDto, Quotation>(MemberList.Source);
            CreateMap<UpdateQuotationDto, Quotation>(MemberList.Source);
            CreateMap<PatchQuotationDto, Quotation>(MemberList.Source)
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
