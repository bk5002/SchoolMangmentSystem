namespace WebApplication10.MiddleWare
{
    public static class MiddleWareWrapper
    {
        public static IApplicationBuilder CookiesToAuthenticationHeaderMiddleWare(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CookiesToAuthenticationHeader>();
        }
    }
}
