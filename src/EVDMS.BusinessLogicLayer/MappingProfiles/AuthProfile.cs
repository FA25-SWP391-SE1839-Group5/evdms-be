using AutoMapper;
using EVDMS.Common.Dtos;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.MappingProfiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<User, LoginResponseDto>()
                .ForMember(dest => dest.AccessToken, opt => opt.Ignore())
                .ForMember(dest => dest.RefreshToken, opt => opt.Ignore());
        }
    }
}
