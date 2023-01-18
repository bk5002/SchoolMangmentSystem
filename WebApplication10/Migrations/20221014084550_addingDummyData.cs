using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication10.Migrations
{
    public partial class addingDummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {   //Dummy User
            migrationBuilder.Sql("Insert Into Users(Name, Email, Password, RoleId) Values('Admin','admin1@gmail.com','11223344',1)");
            migrationBuilder.Sql("Insert Into Users(Name, Email, Password, RoleId) Values('Teacher 1','teacher1@gmail.com','11223344',2)");
            migrationBuilder.Sql("Insert Into Users(Name, Email, Password, RoleId) Values('Teacher 2','teacher2@gmail.com','11223344',2)");
            migrationBuilder.Sql("Insert Into Users(Name, Email, Password, RoleId) Values('Student 1','student1@gmail.com','11223344',3)");
            migrationBuilder.Sql("Insert Into Users(Name, Email, Password, RoleId) Values('Student 2','student2@gmail.com','11223344',3)");
            migrationBuilder.Sql("Insert Into Users(Name, Email, Password, RoleId) Values('Student 3','student3@gmail.com','11223344',3)");
            migrationBuilder.Sql("Insert Into Users(Name, Email, Password, RoleId) Values('Student 4','student4@gmail.com','11223344',3)");

            //Course User
            migrationBuilder.Sql("Insert Into Courses(Title, CreditId) Values('World Litrature',3)");

            migrationBuilder.Sql("Insert Into Courses(Title, CreditId) Values('Islamiat',2)");

            migrationBuilder.Sql("Insert Into Courses(Title, CreditId) Values('Pakistan Study',2)");

            migrationBuilder.Sql("Insert Into Courses(Title, CreditId) Values('Intro To Computer Technology',3)");
            migrationBuilder.Sql("Insert Into Courses(Title, CreditId) Values('Intro To Computer Technology Lab',1)");

            migrationBuilder.Sql("Insert Into Courses(Title, CreditId) Values('Object Orianted Programing (C#)',3)");
            migrationBuilder.Sql("Insert Into Courses(Title, CreditId) Values('Object Orianted Programing (C#) Lab',1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
