using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Text;
using WebApplication10.Context;
using WebApplication10.MiddleWare;
using WebApplication10.UnitOfWork;
using WebApplication10.UnitOfWork.Configuration;
using WebApplication10.Utilites;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option => {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Enums.SecretKey)),
        };
        
        option.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                context.Response.Headers.Add("Failed", context.Exception.GetType().ToString());
                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException)) {
                    context.Response.Headers.Add("Token-Expired", "true");
                }
                return Task.CompletedTask;
            },
            
            
        };
    }
    );

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Enums.IsAdmin, policy =>
    {
        policy.RequireClaim(Enums.MyRole,Enums.Admin);
    });

    options.AddPolicy(Enums.IsTeacher, policy =>
    {   
        policy.RequireClaim(Enums.MyRole, Enums.Teacher);
    });

    options.AddPolicy(Enums.IsStudent, policy =>
    {
        policy.RequireClaim(Enums.MyRole, Enums.Student);
    });
    options.AddPolicy(Enums.IsTeacherOrStudent, policy =>
    {

        policy.RequireClaim(Enums.MyRole, Enums.Student, Enums.Teacher);
    });

});

builder.Services.AddDbContext<SchoolManagmentDB>(option => option.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddScoped<IUnitOfWork,BaseUnitOfWork>();

builder.Services.AddScoped<JWTToken, JWTToken>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.CookiesToAuthenticationHeaderMiddleWare();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}"
);


app.Run();
