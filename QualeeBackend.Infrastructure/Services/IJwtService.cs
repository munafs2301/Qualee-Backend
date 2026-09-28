using System;
using System.Collections.Generic;
using System.Text;

namespace QualeeBackend.Infrastructure.Services
{
    public interface IJwtService
    {
        string GenerateToken(Guid userId, string email, string role);
        bool ValidateToken(string token);
    }
}
