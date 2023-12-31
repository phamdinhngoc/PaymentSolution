﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Payment.Application.Interface;
using System.Security.Claims;

namespace Payment.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public string UserId => httpContextAccessor?.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        public string IpAddress => httpContextAccessor?.HttpContext.Connection?.LocalIpAddress?.ToString();
    }
}
