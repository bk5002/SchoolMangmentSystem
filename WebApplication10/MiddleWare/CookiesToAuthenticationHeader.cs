using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebApplication10.MiddleWare
{
    public class CookiesToAuthenticationHeader
    {
        private readonly RequestDelegate _next;
        public CookiesToAuthenticationHeader(RequestDelegate next) {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var Cookie = context.Request.Cookies["Token"];
            context.Request.Headers.Add("Authorization", "Bearer " + Cookie);
            await _next(context);
        }   
    }
}
