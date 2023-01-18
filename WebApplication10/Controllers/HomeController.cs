using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication10.DTO;
using WebApplication10.UnitOfWork;
using WebApplication10.Utilites;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork, ILogger<HomeController> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [ClaimId]
        public IActionResult Index(string? message, [FromHeader] Parameter parameter)
        {
            if (message != null) {
                Console.WriteLine(message);
            }
            if (User.Identity.IsAuthenticated) {
                if (parameter.Role.ToString() == Enums.Admin) {
                    return View(Enums.AdminView, parameter);
                }
                else if (parameter.Role.ToString() == Enums.Teacher) {
                    ViewData["TeacherCourseList"] = _unitOfWork.TeacherEnrollment.GetMyEnrolment(parameter.Id);
                    return View(Enums.TeacherView, parameter);

                }
                else if (parameter.Role.ToString() == Enums.Student) {
                    ViewData["StudentCourseList"] = _unitOfWork.StudentEnrollment.GetMyEnrolment(parameter.Id);
                    return View(Enums.StudentView, parameter);
                }
            }
            ViewData["Error"] = message;
            return View();
        }

        [Authorize(Policy = Enums.IsAdmin)]
        [ClaimId]
        [Route("/CreateUser")]
        public IActionResult CreateUser(string? message, [FromHeader] Parameter parameter) {

            ViewData["message"] = message;
            return View(parameter);
        }


        [Authorize(Policy = Enums.IsAdmin)]
        [ClaimId]
        [Route("/CreateCourse")]
        public IActionResult CreateCourse(string? message, [FromHeader] Parameter parameter) {

            ViewData["message"] = message;
            return View(parameter);
        }


        [Authorize(Policy = Enums.IsAdmin)]
        [ClaimId]
        [Route("/EnroleUser")]
        public IActionResult EnroleUser(string? message, [FromHeader] Parameter parameter) {


            ViewData["CourseWithoutTeacher"] = _unitOfWork.Course.coursesWithoutTeacher();
            ViewData["Course"] = _unitOfWork.Course.GetAll();
            ViewData["Teacher"] = _unitOfWork.User.GetOnly(Convert.ToInt32(Enums.Teacher));
            ViewData["Student"] = _unitOfWork.User.GetOnly(Convert.ToInt32(Enums.Student));
            ViewData["message"] = message;
            return View(parameter);
        }


        [Authorize(Policy = Enums.IsTeacherOrStudent)]
        [ClaimId]
        public IActionResult CourseDetails([FromQuery] int id, Parameter parameter)
        {
            string view = "StudentCourseDetails";
            if (parameter.Role.ToString() == Enums.Teacher)
            {
                view = "TeacherCourseDetails";
                var result = _unitOfWork.Assignment.GetCourseAssignments(parameter.Id, id);
                try
                {
                    ViewData["Status"] = result.IsNullOrEmpty() ? "p1" : "okay";
                }
                catch (Exception e)
                {
                    ViewData["Status"] = "p2";

                }
                ViewData["TeacherAssignmetList"] = result;
                ViewData["CourseId"] = id;
            }
            else {
                var result = _unitOfWork.Assigned.GetMyAssignments(parameter.Id, id);
                try
                {
                    ViewData["Status"] = result.IsNullOrEmpty() ? "p1" : "okay";
                }
                catch (Exception e)
                {
                    ViewData["Status"] = "p2";

                }
                ViewData["StudentAssignmetList"] = result;
                ViewData["CourseId"] = id;
            }
            return View(view, parameter);
        }

        [Authorize(Policy = Enums.IsTeacher)]
        [ClaimId]
        public IActionResult CreateAssignment(string? message, [FromQuery] int id, Parameter parameter) {
            var EnrollmentDTO = new EnrollmentDTO() { CourseId = id, UserId = parameter.Id };
            var result = _unitOfWork.TeacherEnrollment.GetEnrollmentId(EnrollmentDTO);
            if (result != 0)
            {
                ViewData["EnrollmentId"] = result;
                ViewData["Status"] = "ok";
                ViewData["message"] = message;
            }
            return View(parameter);
        }

        [Authorize(Policy = Enums.IsStudent)]
        [ClaimId]
        public IActionResult SubmitAssignment(string? message, [FromQuery] int id, Parameter parameter)
        {
            var AssignedId = _unitOfWork.Assigned.AssignedId(parameter.Id,id);
            if (AssignedId == 0)
            {
                ViewData["Status"] = "p1";
            }
            else {
                ViewData["AssignedId"] = AssignedId;
                ViewData["message"] = message;

            }
            return View(parameter);
        }


        [Authorize(Policy = Enums.IsTeacher)]
        [ClaimId]
        public IActionResult SubmitionList([FromQuery] int id, Parameter parameter) {
            var result = _unitOfWork.Assigned.GetStudentAssignments(parameter.Id, id);
            if (result == null)
            {
                ViewData["Status"] = "p1";
            }
            else {
                if (!result.IsNullOrEmpty()) {
                    ViewData["TotalMarks"] = _unitOfWork.Assignment.Get(result.FirstOrDefault().AssignmentId).TotalMarks;
                }

                ViewData["SubmitionResult"] = result;
            }
            return View(parameter);
        }
    }
    }