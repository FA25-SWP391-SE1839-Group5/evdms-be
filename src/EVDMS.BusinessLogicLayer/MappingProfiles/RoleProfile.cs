using AutoMapper;
using EVDMS.Common.DTOs;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>();

            CreateMap<CreateRoleDto, Role>(MemberList.Source);
            CreateMap<UpdateRoleDto, Role>(MemberList.Source);
            CreateMap<PatchRoleDto, Role>(MemberList.Source)
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
