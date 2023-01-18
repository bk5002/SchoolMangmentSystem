
using AutoMapper;
using WebApplication10.DTO;
using WebApplication10.Models;

namespace WebApplication10.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Course, CourseDTO>().ForMember(d => d.CreditHourse, opt => opt.MapFrom(s => s.CreditId));
            CreateMap<CourseDTO,Course>().ForMember(d => d.CreditId, opt => opt.MapFrom(s => s.CreditHourse));

            CreateMap<StudentEnrollment,EnrollmentDTO>();
            CreateMap<EnrollmentDTO, StudentEnrollment>();
            
            CreateMap<TeacherEnrollement, EnrollmentDTO>();
            CreateMap<EnrollmentDTO, TeacherEnrollement>();

            CreateMap<User, UserListDTO>().ForMember(dest=>dest.Role, opt => opt.MapFrom(s=>s.Role.UserRole));
            CreateMap<UserListDTO, User>();

            CreateMap<StudentEnrollment, GetMyEnrollmentDTO>();
            CreateMap<GetMyEnrollmentDTO, StudentEnrollment>();

            //CreateMap<Assignment, CreateAssignmentDTO>().ForMember(d=>d.EnrollmentId);
            CreateMap<CreateAssignmentDTO, Assignment>().ForMember(d => d.CourseId, opt => opt.MapFrom(s => s.EnrollmentId));
        }
    }

}
