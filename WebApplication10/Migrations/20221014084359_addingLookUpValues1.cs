using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication10.Migrations
{
    public partial class addingLookUpValues1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into UserRoles(UserRole) values('Admin')");
            migrationBuilder.Sql("Insert Into UserRoles(UserRole) values('Teacher')");
            migrationBuilder.Sql("Insert Into UserRoles(UserRole) values('Student')");

            migrationBuilder.Sql("Insert Into Credits(CreditHour) values(1)");
            migrationBuilder.Sql("Insert Into Credits(CreditHour) values(2)");
            migrationBuilder.Sql("Insert Into Credits(CreditHour) values(3)");

            migrationBuilder.Sql("Insert Into Grades(Min,Max,GPA,GradeValue) values(0,59,0,'F')");
            migrationBuilder.Sql("Insert Into Grades(Min,Max,GPA,GradeValue) values(60,66,2,'C')");
            migrationBuilder.Sql("Insert Into Grades(Min,Max,GPA,GradeValue) values(67,72,2.5,'C+')");
            migrationBuilder.Sql("Insert Into Grades(Min,Max,GPA,GradeValue) values(73,80,3,'B')");
            migrationBuilder.Sql("Insert Into Grades(Min,Max,GPA,GradeValue) values(81,87,3.5,'B+')");
            migrationBuilder.Sql("Insert Into Grades(Min,Max,GPA,GradeValue) values(88,100,4,'A')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
