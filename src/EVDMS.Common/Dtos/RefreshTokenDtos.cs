using System.ComponentModel.DataAnnotations;

namespace EVDMS.Common.Dtos
{
    public class RefreshTokenRequestDto
    {
        [Required]
        public required string RefreshToken { get; set; }
    }

    public class RefreshTokenResponseDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
