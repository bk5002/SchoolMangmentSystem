using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication10.DTO;
using WebApplication10.Models;
using WebApplication10.UnitOfWork;
using WebApplication10.Utilites;

namespace WebApplication10.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public AssignmentController(IUnitOfWork UnitOfWork, IMapper Mapper,IWebHostEnvironment env) {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
            _env = env;
        }

        [HttpPost("CreateAssignment")]
        [Authorize(Policy = Enums.IsTeacher)]
        [ClaimId]
        public IActionResult CreateAssignment([FromForm]CreateAssignmentDTO createAssignmentDTO, [FromHeader] Parameter parameter) {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(new { status = false, message = "Invalid Object" });
            }
            var file = HttpContext.Request.Form.Files;
            if (file.Count > 1) {
                return RedirectToAction("CreateAssignment", "Home",new {message="Can't Submit MultipleFiles, Kindly Zip It!"});
            }
            var assignment = _mapper.Map<Assignment>(createAssignmentDTO);
            string savefilepath = ""; 
            if (file.IsNullOrEmpty())
            {
                assignment.FileUrl = savefilepath;
            }
            else{
            string uniqeFileName = Guid.NewGuid()+Path.GetRandomFileName();
            string extensionName = Path.GetExtension(file[0].FileName);
            var p1 = _env.ContentRootPath;
                // var p2 = _env.WebRootPath;
            savefilepath = Path.Combine(p1,"Files","AssignmentFiles",uniqeFileName+extensionName);
            assignment.FileUrl = savefilepath;
            }
            bool result = _unitOfWork.Assignment.CreateAssignment(parameter.Id, assignment); 
            if (result) {
                if (assignment.FileUrl != "") { 
                using (var stream = System.IO.File.Create(savefilepath))
                {
                    file[0].CopyTo(stream);
                }
                }
                return RedirectToAction("Index", "Home",new { message = "Assignment Is Created" }); 
            }
            return RedirectToAction("CreateAssignment", "Home",new { message = "Invalid Values" }); 
        }
        
        [HttpGet("GetMyAssignment")]
        [Authorize(Policy = Enums.IsStudent)]
        [ClaimId]
        public IActionResult GetMyAssignment(CourseIdDTO courseIdDTO, [FromHeader] Parameter parameter) {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(new { status = false, message = "Invalid Object" });
            }
            var result = _unitOfWork.Assigned.GetMyAssignments(parameter.Id, courseIdDTO.CourseId);
            if (result.IsNullOrEmpty())
            {
                return new BadRequestObjectResult(new { status = false, message = "No Result Found" });
            }
            return new OkObjectResult(new { status = true, date = result });
        }



        [HttpPost("SubmitAssignment")]
        [Authorize(Policy = Enums.IsStudent)]
        [ClaimId]
        public IActionResult SubmitAssignment([FromForm] SubmitAssignmentDTO submitAssignmentDTO, [FromHeader] Parameter parameter)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(new { status = false, message = "Invalid Object" });
            }
            var file = HttpContext.Request.Form.Files;
            if (file.Count > 1)
            {
                return new BadRequestObjectResult(new { status = false, message = "Can't Submit MultipleFiles, Kindly Zip It!" });
            }
            string savefilepath = "";
            string FileUrl = savefilepath;
            if (!file.IsNullOrEmpty())
            {
                string uniqeFileName = Guid.NewGuid() + Path.GetRandomFileName();
                string extensionName = Path.GetExtension(file[0].Name);
                var p1 = _env.ContentRootPath;
                // var p2 = _env.WebRootPath;
                savefilepath = Path.Combine(p1, "Files", "AssignmentFiles", uniqeFileName, extensionName);
                FileUrl = savefilepath;
            }
            bool result = _unitOfWork.Assigned.SubmitAssignment(parameter.Id, Convert.ToInt32(submitAssignmentDTO.AssignedId), FileUrl,submitAssignmentDTO.CommentORAnswer);
            if (result)
            {
                if (FileUrl != "")
                {
                    using (var stream = System.IO.File.Create(savefilepath))
                    {
                        file[0].CopyTo(stream);
                    }
                }
                
                return RedirectToAction("CourseDetails", "Home",new {id=_unitOfWork.Assigned.getCourseId(submitAssignmentDTO.AssignedId)});
            }
            return new BadRequestObjectResult(new { status = false, message = "Invalid Values" });
        }


        [HttpPost("SetMarks")]
        [Authorize(Policy = Enums.IsTeacher)]
        [ClaimId]
        public IActionResult SetMarks(SetMarks setMarks,[FromHeader] Parameter parameter)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(new { status = false, message = "Invalid Object" });
            }
            var Result = _unitOfWork.Assignment.SetMarks(parameter.Id, setMarks);
            if (Result) {
                return new OkObjectResult(new { status = true, message = "Marks Updated" });
            }
            return new BadRequestObjectResult(new { status = true, message = "Invalid Values" });
        }

        
        [HttpGet("GetCourseAssignments")]
        [Authorize(Policy = Enums.IsTeacher)]
        [ClaimId]
        public IActionResult GetCourseAssignments(CourseIdDTO courseIdDTO, [FromHeader] Parameter parameter)
        {
            var result = _unitOfWork.Assignment.GetCourseAssignments(parameter.Id,courseIdDTO.CourseId);
            if (result.IsNullOrEmpty())
            {
                return new BadRequestObjectResult(new { status = false, message = "No Result Found" });
            }
            return new OkObjectResult(new { status = true, date = result });
        }

        
        [HttpGet("GetStudentAssignments")]
        [Authorize(Policy = Enums.IsTeacher)]
        [ClaimId]
        public IActionResult GetStudentAssignments(CourseIdDTO courseIdDTO, [FromHeader] Parameter parameter)
        {
            var result = _unitOfWork.Assigned.GetStudentAssignments(parameter.Id, courseIdDTO.CourseId);
            if (result.IsNullOrEmpty()) {
                return new BadRequestObjectResult(new { status = false, message = "No Result Found" });
            }
            return new OkObjectResult(new { status = true, date = result });
        }


        [HttpGet("download")]
        [Authorize(Policy = Enums.IsTeacherOrStudent)]
        [ClaimId]
        public IActionResult download([FromQuery]int id,[FromHeader] Parameter parameter) {
            string url = "";
            if (parameter.Role.ToString() == Enums.Student) {
                url = _unitOfWork.Assigned.GetMyAssignmentUrl(parameter.Id, id);
                
            }
            if (parameter.Role.ToString() == Enums.Teacher) {
                var assignment = _unitOfWork.Assignment.Get(id);
                if (assignment == null) {
                    return BadRequest();
                }
                var teacherEnrollment = _unitOfWork.TeacherEnrollment.SingleorDefault(t => t.CourseId == assignment.CourseId && t.UserId == parameter.Id);
                if (teacherEnrollment == null || assignment.FileUrl == null)
                {
                    return BadRequest();
                }
                else { 
                    url = assignment.FileUrl;
                }
            }
            var fileBytes = System.IO.File.ReadAllBytes(url);
            var extension = Path.GetExtension(url);
            extension = extension.Substring(1);
            if (url == "") { 
                return BadRequest();
            }
            return File(fileBytes, "application/" + extension , Path.GetFileName(url));

        }
        public IActionResult Index()
        {
            return BadRequest("Invalid Request");
        }
    }
}
