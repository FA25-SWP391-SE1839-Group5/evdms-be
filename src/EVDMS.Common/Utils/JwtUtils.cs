using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using EVDMS.Common.Enums;

namespace EVDMS.Common.Utils
{
    public static class JwtUtils
    {
        public static string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }

        public static string HashRefreshToken(string token)
        {
            var bytes = Encoding.UTF8.GetBytes(token);
            var hash = SHA256.HashData(bytes);
            return Convert.ToBase64String(hash);
        }

        public static DateTime GetRefreshTokenExpiryDate(int expirationDays)
        {
            return DateTime.UtcNow.AddDays(expirationDays);
        }

        public static UserRole? GetUserRoleFromClaims(ClaimsPrincipal user)
        {
            var roleClaim = user.FindFirst(ClaimTypes.Role)?.Value ?? user.FindFirst("role")?.Value;
            if (
                string.IsNullOrEmpty(roleClaim) || !Enum.TryParse<UserRole>(roleClaim, out var role)
            )
                return null;
            return role;
        }

        public static Guid? GetUserIdFromClaims(ClaimsPrincipal user)
        {
            var idClaim =
                user.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? user.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            if (Guid.TryParse(idClaim, out var userId))
                return userId;
            return null;
        }
    }
}
