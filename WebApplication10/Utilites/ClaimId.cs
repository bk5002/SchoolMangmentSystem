using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using WebApplication10.DTO;

namespace WebApplication10.Utilites
{
    public class ClaimId:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var parameter =((Parameter)context.ActionArguments["parameter"]);
            parameter.Id = Convert.ToInt32(context.HttpContext.User.Claims.Where(c=>c.Type == Enums.Id).FirstOrDefault()?.Value);
            parameter.Role = Convert.ToInt32(context.HttpContext.User.Claims.Where(c=>c.Type == Enums.MyRole).FirstOrDefault()?.Value);
        }
    }
}
