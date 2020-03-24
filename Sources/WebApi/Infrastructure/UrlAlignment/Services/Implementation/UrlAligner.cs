using System;
using Microsoft.AspNetCore.Http;

namespace Mmu.IdentityProvider.WebApi.Infrastructure.UrlAlignment.Services.Implementation
{
    public class UrlAligner : IUrlAligner
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UrlAligner(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string MakePathRelative(string absolutePath)
        {
            var request = _httpContextAccessor.HttpContext.Request;

            var basePath = request.Scheme + "://" + request.Host;
            var relativePath = absolutePath.Replace(basePath, string.Empty, StringComparison.OrdinalIgnoreCase);

            return relativePath;
        }
    }
}