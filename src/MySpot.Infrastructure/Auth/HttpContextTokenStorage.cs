using Microsoft.AspNetCore.Http;
using MySpot.Application.DTO;
using MySpot.Application.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpot.Infrastructure.Auth
{
    internal sealed class HttpContextTokenStorage : ITokenStorage
    {
        private const string TokenKey = "jwt";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextTokenStorage(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Set(JwtDto jwt) => _httpContextAccessor.HttpContext?.Items.TryAdd(TokenKey, jwt);

        public JwtDto Get()
        {
            if (_httpContextAccessor.HttpContext is null)
            {
                return null;
            }

            if (_httpContextAccessor.HttpContext.Items.TryGetValue(TokenKey, out var jwt))
            {
                return jwt as JwtDto;
            }

            return null;
        }
    }
}
