using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using WebApplication10.DTO;
using WebApplication10.Models;
using WebApplication10.UnitOfWork;
using WebApplication10.Utilites;

namespace WebApplication10.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EnrollmentController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
        }

        
        [HttpPost("EnrollUser")]
        [Authorize(Policy = Enums.IsAdmin)]
        public ActionResult EnrollUser([FromForm]EnrollmentDTO EnrollmentDTO) {
            if (!ModelState.IsValid) {
                return new BadRequestObjectResult(new { status = false, message = "Invalid Object" });
            }
           
            try {
                int Role = _unitOfWork.User.Get(EnrollmentDTO.UserId).RoleId;
                if (Role.ToString() == Enums.Teacher)
                {
                    if (_unitOfWork.TeacherEnrollment.CheckUserAlreadyEnrolled(EnrollmentDTO))
                    {
                        return RedirectToAction("EnroleUser", "Home", new { message = "Teacher Already Enrolled" });
                    }
                    TeacherEnrollement Enrolment = _mapper.Map<TeacherEnrollement>(EnrollmentDTO);
                    _unitOfWork.TeacherEnrollment.Add(Enrolment);
                }

                else if (Role.ToString() == Enums.Student) {
                    if (_unitOfWork.StudentEnrollment.CheckUserAlreadyEnrolled(EnrollmentDTO))
                    {
                        return RedirectToAction("EnroleUser", "Home", new { message = "Student Already Enrolled" });
                    }
                    StudentEnrollment Enrolment = _mapper.Map<StudentEnrollment>(EnrollmentDTO);
                    _unitOfWork.StudentEnrollment.Add(Enrolment);

                }
                _unitOfWork.SaveChanges();
            }
            catch  {
                return new BadRequestObjectResult(new { status = false, message = "Invalid Values" });
            }

            return RedirectToAction("EnroleUser", "Home", new { message = "User SuccessFully Enrolled" });
        
        }

        [HttpPost(("GetMyEnrollment"))]
        [Authorize]
        [ClaimId]
        public ActionResult GetMyEnrollment([FromHeader]Parameter parameter)
        {
            int Role = _unitOfWork.User.Get(parameter.Id).RoleId;
            IEnumerable<GetMyEnrollmentDTO> getMyEnrollmentDTO = null;
            if (Role.ToString() == Enums.Teacher) {
            var list = _unitOfWork.TeacherEnrollment.GetMyEnrolment(parameter.Id);
            getMyEnrollmentDTO = _mapper.Map<IEnumerable<GetMyEnrollmentDTO>>(list);
            }

            else if (Role.ToString() == Enums.Student) {
            var list = _unitOfWork.StudentEnrollment.GetMyEnrolment(parameter.Id);
            getMyEnrollmentDTO = _mapper.Map<IEnumerable<GetMyEnrollmentDTO>>(list);
            }

             return new OkObjectResult(new { status = true, data = getMyEnrollmentDTO });
        }

        public ActionResult Index()
        {
            return BadRequest("Invalid Request");
        }
    }
}
