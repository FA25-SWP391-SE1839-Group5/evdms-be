using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(
                    dest => dest.DealerName,
                    opt => opt.MapFrom(src => src.Dealer != null ? src.Dealer.Name : null)
                );

            CreateMap<CreateUserDto, User>(MemberList.Source)
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive ?? true));

            CreateMap<UpdateUserDto, User>(MemberList.Source);

            CreateMap<PatchUserDto, User>(MemberList.Source)
                .ForAllMembers(
                    (opts) =>
                        opts.Condition(
                            (src, dest, srcMember, context) =>
                                opts.DestinationMember.Name == nameof(User.Role)
                                    ? src.Role.HasValue
                                    : srcMember != null
                                        && !(srcMember is Guid guid && guid == Guid.Empty)
                                        && !(srcMember is DateTime dt && dt == default)
                        )
                );
        }
    }
}
