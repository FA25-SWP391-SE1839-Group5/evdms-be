using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class SalesOrderProfile : Profile
    {
        public SalesOrderProfile()
        {
            CreateMap<SalesOrder, SalesOrderDto>();
            CreateMap<CreateSalesOrderDto, SalesOrder>(MemberList.Source);
            CreateMap<UpdateSalesOrderDto, SalesOrder>(MemberList.Source);
            CreateMap<PatchSalesOrderDto, SalesOrder>(MemberList.Source)
                .ForAllMembers(opts =>
                    opts.Condition(
                        (src, dest, srcMember, context) =>
                            srcMember != null
                            && !(srcMember is Guid guid && guid == Guid.Empty)
                            && !(srcMember is DateTime dt && dt == default)
                    )
                );

            CreateMap<SalesOrder, SalesOrderSummaryDto>();
            CreateMap<SalesOrder, DealerStaffSalesReportDto>()
                .ForMember(dest => dest.StaffId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.User.FullName));
            CreateMap<SalesOrder, DealerTotalSalesReportDto>()
                .ForMember(dest => dest.DealerId, opt => opt.MapFrom(src => src.DealerId))
                .ForMember(dest => dest.DealerName, opt => opt.MapFrom(src => src.Dealer.Name))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Dealer.Region));
        }
    }
}
