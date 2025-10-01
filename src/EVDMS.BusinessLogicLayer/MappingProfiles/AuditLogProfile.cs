using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class AuditLogProfile : Profile
    {
        public AuditLogProfile()
        {
            CreateMap<AuditLog, AuditLogDto>();

            CreateMap<CreateAuditLogDto, AuditLog>(MemberList.Source);
            CreateMap<UpdateAuditLogDto, AuditLog>(MemberList.Source);
            CreateMap<PatchAuditLogDto, AuditLog>(MemberList.Source)
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
