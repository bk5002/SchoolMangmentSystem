﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication10.Context;

#nullable disable

namespace WebApplication10.Migrations
{
    [DbContext(typeof(SchoolManagmentDB))]
    partial class SchoolManagmentDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication10.Models.Assigned", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<string>("CommentOrAnswer")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("FileUrl")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<byte?>("ObtainMarks")
                        .HasColumnType("tinyint");

                    b.Property<string>("Remarks")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SubmitDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Assigneds");
                });

            modelBuilder.Entity("WebApplication10.Models.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileUrl")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Instruction")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("TotalMarks")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("WebApplication10.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte>("CreditId")
                        .HasColumnType("tinyint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CreditId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("WebApplication10.Models.Credit", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<byte>("Id"), 1L, 1);

                    b.Property<byte>("CreditHour")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Credits");
                });

            modelBuilder.Entity("WebApplication10.Models.Grade", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<byte>("Id"), 1L, 1);

                    b.Property<decimal>("GPA")
                        .HasColumnType("smallmoney");

                    b.Property<string>("GradeValue")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<byte>("Max")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Min")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("WebApplication10.Models.Role", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<byte>("Id"), 1L, 1);

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("WebApplication10.Models.StoreProcedureResult", b =>
                {
                    b.Property<int>("FlowStatus")
                        .HasColumnType("int");

                    b.ToTable("StoreProcedureResults");
                });

            modelBuilder.Entity("WebApplication10.Models.StudentEnrollment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<byte?>("GradeId")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("Marks")
                        .HasColumnType("tinyint");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("GradeId");

                    b.HasIndex("UserId");

                    b.ToTable("StudentsEnrollments");
                });

            modelBuilder.Entity("WebApplication10.Models.TeacherEnrollement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("TeacherEnrollements");
                });

            modelBuilder.Entity("WebApplication10.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("EnrolmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("RoleId")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication10.Models.Assigned", b =>
                {
                    b.HasOne("WebApplication10.Models.Assignment", "Assignment")
                        .WithMany()
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication10.Models.User", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("WebApplication10.Models.Assignment", b =>
                {
                    b.HasOne("WebApplication10.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("WebApplication10.Models.Course", b =>
                {
                    b.HasOne("WebApplication10.Models.Credit", "Credit")
                        .WithMany()
                        .HasForeignKey("CreditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Credit");
                });

            modelBuilder.Entity("WebApplication10.Models.StudentEnrollment", b =>
                {
                    b.HasOne("WebApplication10.Models.Course", "Course")
                        .WithMany("StudentEnrollment")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication10.Models.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeId");

                    b.HasOne("WebApplication10.Models.User", "User")
                        .WithMany("StudentEnrollment")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Grade");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication10.Models.TeacherEnrollement", b =>
                {
                    b.HasOne("WebApplication10.Models.Course", "Course")
                        .WithMany("TeacherEnrollement")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication10.Models.User", "User")
                        .WithMany("TeacherEnrollement")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication10.Models.User", b =>
                {
                    b.HasOne("WebApplication10.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebApplication10.Models.Course", b =>
                {
                    b.Navigation("StudentEnrollment");

                    b.Navigation("TeacherEnrollement");
                });

            modelBuilder.Entity("WebApplication10.Models.User", b =>
                {
                    b.Navigation("StudentEnrollment");

                    b.Navigation("TeacherEnrollement");
                });
#pragma warning restore 612, 618
        }
    }
}
