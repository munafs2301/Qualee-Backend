using System;
using System.Collections.Generic;
using System.Text;

namespace QualeeBackend.Application.DTOs
{
    public record LoginRequestDto(string Email, string Password);
    public record LoginResponseDto(string Token, DateTime Expiry, string Role);
}
