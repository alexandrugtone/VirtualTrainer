﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VirtualTrainer;

namespace VirtualTrainer.Migrations
{
    [DbContext(typeof(SaliFitnessContext))]
    partial class SaliFitnessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VirtualTrainer.BodyGroup", b =>
                {
                    b.Property<int>("IdbodyGroup")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDBodyGroup")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IdbodyGroup");

                    b.ToTable("BodyGroup");
                });

            modelBuilder.Entity("VirtualTrainer.Equipment", b =>
                {
                    b.Property<int>("Idequipment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDEquipment")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EquipmentName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Idequipment");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("VirtualTrainer.EquipmentExercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Idequipment")
                        .HasColumnType("int")
                        .HasColumnName("IDEquipment");

                    b.Property<int>("Idexercise")
                        .HasColumnType("int")
                        .HasColumnName("IDExercise");

                    b.HasKey("Id");

                    b.HasIndex("Idequipment");

                    b.HasIndex("Idexercise");

                    b.ToTable("Equipment_Exercises");
                });

            modelBuilder.Entity("VirtualTrainer.Exercise", b =>
                {
                    b.Property<int>("Idexercise")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDExercise")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExerciseName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Reps")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((12))");

                    b.Property<int>("Sets")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((3))");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Idexercise");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("VirtualTrainer.GroupEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdbodyGroup")
                        .HasColumnType("int")
                        .HasColumnName("IDBodyGroup");

                    b.Property<int>("Idequipment")
                        .HasColumnType("int")
                        .HasColumnName("IDEquipment");

                    b.HasKey("Id");

                    b.HasIndex("IdbodyGroup");

                    b.HasIndex("Idequipment");

                    b.ToTable("Group_Equipment");
                });

            modelBuilder.Entity("VirtualTrainer.ProgramExercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Idexercise")
                        .HasColumnType("int")
                        .HasColumnName("IDExercise");

                    b.Property<int>("IdworkProgram")
                        .HasColumnType("int")
                        .HasColumnName("IDWorkProgram");

                    b.HasKey("Id");

                    b.HasIndex("Idexercise");

                    b.ToTable("Program_Exercise");
                });

            modelBuilder.Entity("VirtualTrainer.ProgramType", b =>
                {
                    b.Property<int>("IdprogramType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDProgramType")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProgramTypeName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IdprogramType");

                    b.ToTable("ProgramType");
                });

            modelBuilder.Entity("VirtualTrainer.ProgramUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Iduser")
                        .HasColumnType("int")
                        .HasColumnName("IDUser");

                    b.Property<int>("IdworkProgram")
                        .HasColumnType("int")
                        .HasColumnName("IDWorkProgram");

                    b.HasKey("Id");

                    b.HasIndex("Iduser");

                    b.HasIndex("IdworkProgram");

                    b.ToTable("Program_Users");
                });

            modelBuilder.Entity("VirtualTrainer.Subscription", b =>
                {
                    b.Property<int>("Idsubscription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDSubscription")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AllowedTimeInterval")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SubName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Idsubscription");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("VirtualTrainer.TypeGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdbodyGroup")
                        .HasColumnType("int")
                        .HasColumnName("IDBodyGroup");

                    b.Property<int>("IdprogramType")
                        .HasColumnType("int")
                        .HasColumnName("IDProgramType");

                    b.HasKey("Id");

                    b.HasIndex("IdbodyGroup");

                    b.HasIndex("IdprogramType");

                    b.ToTable("Type_Group");
                });

            modelBuilder.Entity("VirtualTrainer.User", b =>
                {
                    b.Property<int>("Iduser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDUser")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Cnp")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)")
                        .HasColumnName("CNP");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Iduser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VirtualTrainer.UserSubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("Idsubscription")
                        .HasColumnType("int")
                        .HasColumnName("IDSubscription");

                    b.Property<int>("Iduser")
                        .HasColumnType("int")
                        .HasColumnName("IDUser");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("Idsubscription");

                    b.HasIndex("Iduser");

                    b.ToTable("User_Subscription");
                });

            modelBuilder.Entity("VirtualTrainer.UsersExercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Idexercise")
                        .HasColumnType("int")
                        .HasColumnName("IDExercise");

                    b.Property<int>("Iduser")
                        .HasColumnType("int")
                        .HasColumnName("IDUser");

                    b.HasKey("Id");

                    b.HasIndex("Idexercise");

                    b.HasIndex("Iduser");

                    b.ToTable("Users_Exercises");
                });

            modelBuilder.Entity("VirtualTrainer.WorkProgram", b =>
                {
                    b.Property<int>("IdworkProgram")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDWorkProgram")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProgramName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IdworkProgram");

                    b.ToTable("WorkProgram");
                });

            modelBuilder.Entity("VirtualTrainer.WorkType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdprogramType")
                        .HasColumnType("int")
                        .HasColumnName("IDProgramType");

                    b.Property<int>("IdworkProgram")
                        .HasColumnType("int")
                        .HasColumnName("IDWorkProgram");

                    b.HasKey("Id");

                    b.HasIndex("IdprogramType");

                    b.HasIndex("IdworkProgram");

                    b.ToTable("Work_Type");
                });

            modelBuilder.Entity("VirtualTrainer.EquipmentExercise", b =>
                {
                    b.HasOne("VirtualTrainer.Equipment", "IdequipmentNavigation")
                        .WithMany("EquipmentExercises")
                        .HasForeignKey("Idequipment")
                        .HasConstraintName("FK_Equipment_Exercises_Equipment")
                        .IsRequired();

                    b.HasOne("VirtualTrainer.Exercise", "IdexerciseNavigation")
                        .WithMany("EquipmentExercises")
                        .HasForeignKey("Idexercise")
                        .HasConstraintName("FK_Equipment_Exercises_Exercises")
                        .IsRequired();

                    b.Navigation("IdequipmentNavigation");

                    b.Navigation("IdexerciseNavigation");
                });

            modelBuilder.Entity("VirtualTrainer.GroupEquipment", b =>
                {
                    b.HasOne("VirtualTrainer.BodyGroup", "IdbodyGroupNavigation")
                        .WithMany("GroupEquipments")
                        .HasForeignKey("IdbodyGroup")
                        .HasConstraintName("FK_Group_Equipment_BodyGroup")
                        .IsRequired();

                    b.HasOne("VirtualTrainer.Equipment", "IdequipmentNavigation")
                        .WithMany("GroupEquipments")
                        .HasForeignKey("Idequipment")
                        .HasConstraintName("FK_Group_Equipment_Equipment")
                        .IsRequired();

                    b.Navigation("IdbodyGroupNavigation");

                    b.Navigation("IdequipmentNavigation");
                });

            modelBuilder.Entity("VirtualTrainer.ProgramExercise", b =>
                {
                    b.HasOne("VirtualTrainer.Exercise", "IdexerciseNavigation")
                        .WithMany("ProgramExercises")
                        .HasForeignKey("Idexercise")
                        .HasConstraintName("FK_Program_Exercise_Exercises")
                        .IsRequired();

                    b.Navigation("IdexerciseNavigation");
                });

            modelBuilder.Entity("VirtualTrainer.ProgramUser", b =>
                {
                    b.HasOne("VirtualTrainer.User", "IduserNavigation")
                        .WithMany("ProgramUsers")
                        .HasForeignKey("Iduser")
                        .HasConstraintName("FK_Program_Users_Users")
                        .IsRequired();

                    b.HasOne("VirtualTrainer.WorkProgram", "IdworkProgramNavigation")
                        .WithMany("ProgramUsers")
                        .HasForeignKey("IdworkProgram")
                        .HasConstraintName("FK_Program_Users_WorkProgram")
                        .IsRequired();

                    b.Navigation("IduserNavigation");

                    b.Navigation("IdworkProgramNavigation");
                });

            modelBuilder.Entity("VirtualTrainer.TypeGroup", b =>
                {
                    b.HasOne("VirtualTrainer.BodyGroup", "IdbodyGroupNavigation")
                        .WithMany("TypeGroups")
                        .HasForeignKey("IdbodyGroup")
                        .HasConstraintName("FK_Type_Group_BodyGroup")
                        .IsRequired();

                    b.HasOne("VirtualTrainer.ProgramType", "IdprogramTypeNavigation")
                        .WithMany("TypeGroups")
                        .HasForeignKey("IdprogramType")
                        .HasConstraintName("FK_Type_Group_ProgramType")
                        .IsRequired();

                    b.Navigation("IdbodyGroupNavigation");

                    b.Navigation("IdprogramTypeNavigation");
                });

            modelBuilder.Entity("VirtualTrainer.UserSubscription", b =>
                {
                    b.HasOne("VirtualTrainer.Subscription", "IdsubscriptionNavigation")
                        .WithMany("UserSubscriptions")
                        .HasForeignKey("Idsubscription")
                        .HasConstraintName("FK_User_Subscription_Subscriptions")
                        .IsRequired();

                    b.HasOne("VirtualTrainer.User", "IduserNavigation")
                        .WithMany("UserSubscriptions")
                        .HasForeignKey("Iduser")
                        .HasConstraintName("FK_User_Subscription_Users")
                        .IsRequired();

                    b.Navigation("IdsubscriptionNavigation");

                    b.Navigation("IduserNavigation");
                });

            modelBuilder.Entity("VirtualTrainer.UsersExercise", b =>
                {
                    b.HasOne("VirtualTrainer.Exercise", "IdexerciseNavigation")
                        .WithMany("UsersExercises")
                        .HasForeignKey("Idexercise")
                        .HasConstraintName("FK_Users_Exercises_Exercises")
                        .IsRequired();

                    b.HasOne("VirtualTrainer.User", "IduserNavigation")
                        .WithMany("UsersExercises")
                        .HasForeignKey("Iduser")
                        .HasConstraintName("FK_Users_Exercises_Users")
                        .IsRequired();

                    b.Navigation("IdexerciseNavigation");

                    b.Navigation("IduserNavigation");
                });

            modelBuilder.Entity("VirtualTrainer.WorkType", b =>
                {
                    b.HasOne("VirtualTrainer.ProgramType", "IdprogramTypeNavigation")
                        .WithMany("WorkTypes")
                        .HasForeignKey("IdprogramType")
                        .HasConstraintName("FK_Work_Type_ProgramType")
                        .IsRequired();

                    b.HasOne("VirtualTrainer.WorkProgram", "IdworkProgramNavigation")
                        .WithMany("WorkTypes")
                        .HasForeignKey("IdworkProgram")
                        .HasConstraintName("FK_Work_Type_WorkProgram")
                        .IsRequired();

                    b.Navigation("IdprogramTypeNavigation");

                    b.Navigation("IdworkProgramNavigation");
                });

            modelBuilder.Entity("VirtualTrainer.BodyGroup", b =>
                {
                    b.Navigation("GroupEquipments");

                    b.Navigation("TypeGroups");
                });

            modelBuilder.Entity("VirtualTrainer.Equipment", b =>
                {
                    b.Navigation("EquipmentExercises");

                    b.Navigation("GroupEquipments");
                });

            modelBuilder.Entity("VirtualTrainer.Exercise", b =>
                {
                    b.Navigation("EquipmentExercises");

                    b.Navigation("ProgramExercises");

                    b.Navigation("UsersExercises");
                });

            modelBuilder.Entity("VirtualTrainer.ProgramType", b =>
                {
                    b.Navigation("TypeGroups");

                    b.Navigation("WorkTypes");
                });

            modelBuilder.Entity("VirtualTrainer.Subscription", b =>
                {
                    b.Navigation("UserSubscriptions");
                });

            modelBuilder.Entity("VirtualTrainer.User", b =>
                {
                    b.Navigation("ProgramUsers");

                    b.Navigation("UsersExercises");

                    b.Navigation("UserSubscriptions");
                });

            modelBuilder.Entity("VirtualTrainer.WorkProgram", b =>
                {
                    b.Navigation("ProgramUsers");

                    b.Navigation("WorkTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
