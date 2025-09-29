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
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
