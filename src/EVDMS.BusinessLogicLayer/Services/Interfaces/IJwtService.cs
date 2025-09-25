using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.BusinessLogicLayer.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
    }
}
