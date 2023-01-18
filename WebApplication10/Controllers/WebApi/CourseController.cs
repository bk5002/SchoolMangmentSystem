using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.DTO;
using WebApplication10.Models;
using WebApplication10.UnitOfWork;
using WebApplication10.Utilites;

namespace WebApplication10.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
        }

       
        [HttpPost("Create")]
        [Authorize(Policy = Enums.IsAdmin)]
        public ActionResult Create([FromForm]CourseDTO courseDTO) {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(new { status = false, message = "Invalid Object" });
            }
            Course course = _mapper.Map<Course>(courseDTO);
            try
            {
                _unitOfWork.Course.Add(course);
                _unitOfWork.SaveChanges();
            }
            catch{
                return new BadRequestObjectResult(new { status = false, message = "Invalid Values" });

            }
            return RedirectToAction("CreateCourse", "Home", new { message = "Course Created" });
            
        }
        
        [HttpPost(("GetAll"))]
        [Authorize(Policy = Enums.IsAdmin)]
        public ActionResult GetAll()
        {
            var list = _unitOfWork.Course.GetAll();
            IEnumerable<CourseDTO> courseDTOList = _mapper.Map<IEnumerable<CourseDTO>>(list);
            return new OkObjectResult(new { status=true ,courses= courseDTOList });
        }

        
        public ActionResult Index()
        {
            return BadRequest("Invalid Request");
        }
    }
}
