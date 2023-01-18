using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication10.Migrations
{
    public partial class addingStoreProcedure1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.Sql("CREATE Procedure [dbo].[AddAssignment]\r\n@TeacherId int, \r\n@EnrollmentId int,\r\n@Title nvarchar(100),\r\n@FileUrl nvarchar(250),\r\n@Instruction nvarchar(350), \r\n@TotalMarks tinyint,\r\n@Deadline datetime2\r\n\r\nAS\r\nBegin\r\n\t Declare @CourseId int \r\n\t Declare @AssignmentId int \r\n\t Declare @Status  bit = 0 \r\n\r\n\t Select @CourseId = CourseId From TeacherEnrollements Where @TeacherId = UserId and @EnrollmentId = Id\r\n\t \r\n\t if IsNull(@CourseId,0)>0  or @TotalMarks between 0 and 100 \r\n\t Begin\r\n\t\tBegin Transaction AddAssignment\r\n\t\tBEGIN TRY\r\n\t\t\r\n\t\tInsert Into Assignments(FileUrl,Instruction,TotalMarks,CourseId,CreatedDate,Deadline,Title) \r\n\t\tSelect @FileUrl,@Instruction,@TotalMarks,@CourseId,GETDATE(),@Deadline,@Title\r\n\t\t\r\n\t\tSelect @AssignmentId = SCOPE_IDENTITY()\r\n\t\tprint @AssignmentId\r\n\r\n\t\tInsert Into Assigneds(AssignmentId,StudentId)\r\n\t\tSelect @AssignmentId,UserId From StudentsEnrollments\r\n\t\tWhere CourseId = @CourseId\r\n\r\n\t\tSet @Status = 1\r\n\t\tCommit Transaction AddAssignment\r\n\t\tEND TRY\r\n\t\t\r\n\t\tBEGIN CATCH\r\n\t\r\n\t\tRollBack Transaction AddAssignment\r\n\t\tEND CATCH\r\n\r\n\t End\r\n\t\tSelect @Status As FlowStatus\r\n\r\nEnd");
            migrationBuilder.Sql("CREATE Procedure [dbo].[SetMarksAndRemarks]\r\n@TeacherId int,\r\n@AssignmentId int,\r\n@AssignedId int,\r\n@ObtainMarks tinyint,\r\n@Remarks nvarchar(350)\r\nAs\r\nBegin\r\n\t\tDeclare @Status bit = 0 \r\n\t\tDeclare @CheckTeacherId int = 0\r\n\t\tDeclare @CheckAssignmentId int = 0\r\n\t\tDeclare @CheckMarks tinyint = 0\r\n\r\n\r\n\t\tSelect @CheckAssignmentId = AssignmentId\r\n\t\tFrom Assigneds \r\n\t\tWhere Id = @AssignedId \r\n\r\n\t\tSelect @CheckTeacherId = b.UserId, @CheckMarks = a.TotalMarks\r\n\t\tFrom Assignments a \r\n\t\tInner Join TeacherEnrollements b \r\n\t\tOn a.Id = @AssignmentId\r\n\t\r\n\t\tif @TeacherId = @CheckTeacherId and @CheckAssignmentId =  @AssignmentId and @ObtainMarks <= @CheckMarks\r\n\t\tBegin\r\n\t\t\t Update Assigneds Set ObtainMarks = @ObtainMarks,  Remarks = @Remarks \r\n\t\t\t Where Id = @AssignedId\r\n\t\t\t Set @Status = 1\r\n\t\tEnd\r\n\t\tSelect @Status As FlowStatus\r\nEnd\r\n");
            migrationBuilder.Sql("CREATE Procedure [dbo].[SubmitAssignment]\r\n@StudentId int,\r\n@AssignedId int,\r\n@FileUrl nvarchar(250),\r\n@CommentORAnswer nvarchar(350)\r\n\r\nAs\r\n\r\nBegin\r\n\tDeclare @Status bit = 0 \r\n\tDeclare @CurrentAssigned int = 0\r\n\tDeclare @CheckSubmittedDate datetime2 \r\n\tSelect @CurrentAssigned = Id, @CheckSubmittedDate = SubmitDate From Assigneds \r\n\tWhere @StudentId = StudentId and @AssignedId = Id\r\n\r\n\tif @CurrentAssigned>0 and IsNull(@CheckSubmittedDate,'') != ''\r\n\tBegin\r\n\t\tUpdate Assigneds Set FileUrl = @FileUrl, CommentOrAnswer = @CommentORAnswer , SubmitDate = GETDATE() Where Id = @CurrentAssigned\r\n\t\tSet @Status = 1\r\n\tEnd\r\n\tSelect @Status As FlowStatus\r\nEnd");
            migrationBuilder.Sql("CREATE Procedure [dbo].[GetCourseAssignment]\r\n@TeacherId int, \r\n@CourseId int\r\nAS\r\nBegin \r\n\t Declare @CheckTeacherId int \r\n\t Select  @CheckTeacherId = UserId From TeacherEnrollements\r\n\t Where CourseId =@CourseId and UserId=@TeacherId\r\n\t \r\n\t if @CheckTeacherId = @TeacherId\r\n\t Begin\r\n\t Select * From Assignments \r\n\t Where CourseId  = @CourseId \r\n\t End\r\n\t Else\r\n\t Begin\r\n\t Select Null\r\n\t End\r\nEnd");
            migrationBuilder.Sql("CREATE Procedure [dbo].[GetStudentAssignments]\r\n@TeacherId int, \r\n@CourseId int\r\nAS\r\nBegin \r\n\t Declare @CheckTeacherId int \r\n\t Select  @CheckTeacherId = UserId From TeacherEnrollements\r\n\t Where CourseId =@CourseId and UserId=@TeacherId\r\n\t \r\n\t if @CheckTeacherId = @TeacherId\r\n\t Begin\r\n\t Select * From Assigneds \r\n\t Where AssignmentId In(Select Id From Assignments Where CourseId = @CourseId)\r\n\t End\r\n\t Else\r\n\t Begin\r\n\t Select Null\r\n\t End\r\nEnd");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
