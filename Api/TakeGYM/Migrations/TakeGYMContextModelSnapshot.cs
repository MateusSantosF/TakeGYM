﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TakeGYM.Services.AppDbContext;

namespace TakeGYM.Migrations
{
    [DbContext(typeof(TakeGYMContext))]
    partial class TakeGYMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TakeGYM.Models.Exercise.Exercise", b =>
                {
                    b.Property<long>("ExerciseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BodyRegion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExerciseID");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("TakeGYM.Models.ExerciseTrainingSheet.ExerciseTraningsheet", b =>
                {
                    b.Property<long>("ExerciseID")
                        .HasColumnType("bigint");

                    b.Property<long>("TrainingsheetID")
                        .HasColumnType("bigint");

                    b.Property<long>("ExerciseID1")
                        .HasColumnType("bigint");

                    b.Property<int>("NumbersIteration")
                        .HasColumnType("int");

                    b.Property<int>("NumbersOfSet")
                        .HasColumnType("int");

                    b.HasKey("ExerciseID", "TrainingsheetID");

                    b.HasIndex("ExerciseID1");

                    b.ToTable("Exercise_Trainingsheet");
                });

            modelBuilder.Entity("TakeGYM.Models.PersonalAlert.PersonalAlert", b =>
                {
                    b.Property<long>("PersonalAlertID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("PersonalID")
                        .HasColumnType("bigint");

                    b.Property<long>("StudentID")
                        .HasColumnType("bigint");

                    b.Property<string>("TrainingSheetObjective")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonalAlertID");

                    b.HasIndex("PersonalID");

                    b.HasIndex("StudentID");

                    b.ToTable("Alert");
                });

            modelBuilder.Entity("TakeGYM.Models.Structures.WorkSchedule", b =>
                {
                    b.Property<long>("WorkScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("TeacherID")
                        .HasColumnType("bigint");

                    b.HasKey("WorkScheduleID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("TakeGYM.Models.Student.Student", b =>
                {
                    b.Property<long>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasPersonal")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TeacherID")
                        .HasColumnType("bigint");

                    b.HasKey("StudentID");

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasFilter("[Phone] IS NOT NULL");

                    b.HasIndex("TeacherID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("TakeGYM.Models.Teacher.Teacher", b =>
                {
                    b.Property<long>("TeacherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPersonal")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TeacherID");

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasFilter("[Phone] IS NOT NULL");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("TakeGYM.Models.TrainingSheet.TrainingSheet", b =>
                {
                    b.Property<long>("TraningSheetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("PersonalID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrainingSheetObjective")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TraningSheetID");

                    b.HasIndex("PersonalID");

                    b.ToTable("TrainingSheet");
                });

            modelBuilder.Entity("TakeGYM.Models.ExerciseTrainingSheet.ExerciseTraningsheet", b =>
                {
                    b.HasOne("TakeGYM.Models.TrainingSheet.TrainingSheet", "Trainingsheet")
                        .WithMany("Exercises")
                        .HasForeignKey("ExerciseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TakeGYM.Models.Exercise.Exercise", "Exercise")
                        .WithMany("TrainingSheets")
                        .HasForeignKey("ExerciseID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TakeGYM.Models.PersonalAlert.PersonalAlert", b =>
                {
                    b.HasOne("TakeGYM.Models.Teacher.Teacher", "Personal")
                        .WithMany("Alerts")
                        .HasForeignKey("PersonalID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TakeGYM.Models.Student.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TakeGYM.Models.Structures.WorkSchedule", b =>
                {
                    b.HasOne("TakeGYM.Models.Teacher.Teacher", null)
                        .WithMany("WorkSchedules")
                        .HasForeignKey("TeacherID");
                });

            modelBuilder.Entity("TakeGYM.Models.Student.Student", b =>
                {
                    b.HasOne("TakeGYM.Models.Teacher.Teacher", "Teacher")
                        .WithMany("Students")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("TakeGYM.Models.TrainingSheet.TrainingSheet", b =>
                {
                    b.HasOne("TakeGYM.Models.Teacher.Teacher", "Personal")
                        .WithMany()
                        .HasForeignKey("PersonalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
