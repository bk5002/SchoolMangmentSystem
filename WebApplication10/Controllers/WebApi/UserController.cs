using Microsoft.AspNetCore.Mvc;
using WebApplication10.DTO;
using WebApplication10.Models;
using WebApplication10.UnitOfWork;
using AutoMapper;
using WebApplication10.Utilites;
using Microsoft.AspNetCore.Authorization;
namespace WebApplication10.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        JWTToken _jwt;
        public UserController(IUnitOfWork UnitOfWork, IMapper Mapper,JWTToken jWTToken) {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
            _jwt = jWTToken;
        }

        [HttpPost("Login")]
        public ActionResult Login([FromForm]LoginDTO LoginDTO) {
            if (!ModelState.IsValid) {
                return new BadRequestObjectResult(new { status = false, message = "Invalid Object"});
            }
            User user = _unitOfWork.User.Login(LoginDTO.Email.Trim().ToLower(), LoginDTO.Password);
            if (user==null) 
            {
                return RedirectToAction("Index", "Home",new { message = "Record Not Found"});
            }
            var Token = _jwt.GetToken(user.Id.ToString(), user.Role.Id.ToString());
            HttpContext.Response.Cookies.Append("Token", Token, new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(1),
                Secure = true,
                HttpOnly = true
            });
            return RedirectToAction("Index","Home");
        }

        [Route("Logout")]
        public ActionResult Logout()
        {
            HttpContext.Response.Cookies.Append("Token","", new CookieOptions()
            {
                Expires = DateTime.Now,
                Secure = true,
                HttpOnly = true
            });
            return RedirectToAction("Index", "Home");
        }

        [HttpPost("Create")]
        [Authorize(Policy = Enums.IsAdmin)]
        public ActionResult Create([FromForm] UserDTO user) {
            if (!ModelState.IsValid || user.RoleId.ToString()==Enums.Admin || user.Name.Trim().Length < 3)
            {
                return RedirectToAction("CreateUser", "Home", new { message = "Invalid Object"});
            }
            User myuser = _mapper.Map<User>(user);
            myuser.Email = myuser.Email.Trim().ToLower();
            try
            {
                _unitOfWork.User.Add(myuser);
                _unitOfWork.SaveChanges();
            }
            catch {
                return RedirectToAction("CreateUser", "Home", new { message = "Email Already Exist"});
            }
            return RedirectToAction("CreateUser", "Home", new { message = "User Added"});

        }


        [HttpPost(("GetOnly"))]
        [Authorize(Policy = Enums.IsAdmin)]
        public ActionResult GetOnly(Parameter parameter)
        {
            if (!ModelState.IsValid || parameter.Id.ToString() == Enums.Admin)
            {
                return new BadRequestObjectResult(new { status = false, message = "Invalid Object" });
            }
            IEnumerable<User> list = _unitOfWork.User.GetOnly(parameter.Id);
            IEnumerable<UserListDTO> userlistdto = _mapper.Map< IEnumerable<UserListDTO>>(list);
            return Ok(new { status = true, user= userlistdto });  
        }

        
        public ActionResult Index()
        {
            return BadRequest("Invalid Request");
        }
    }
}

