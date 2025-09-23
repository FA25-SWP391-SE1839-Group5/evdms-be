using AutoMapper;
using EVDMS.Common.DTOs;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();

            CreateMap<CreateCustomerDto, Customer>(MemberList.Source);
            CreateMap<UpdateCustomerDto, Customer>(MemberList.Source);
            CreateMap<PatchCustomerDto, Customer>(MemberList.Source)
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
