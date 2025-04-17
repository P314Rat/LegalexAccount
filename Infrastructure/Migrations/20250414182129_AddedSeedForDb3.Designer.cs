﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250414182129_AddedSeedForDb3")]
    partial class AddedSeedForDb3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CaseSpecialist", b =>
                {
                    b.Property<Guid>("AssigneeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.HasKey("AssigneeId", "CaseId");

                    b.HasIndex("CaseId");

                    b.ToTable("CaseSpecialist");
                });

            modelBuilder.Entity("Domain.Core.AccountAggregate.PasswordResetToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PasswordResetTokens");
                });

            modelBuilder.Entity("Domain.Core.CaseAggregate.Case", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ArchivedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstimatedDaysToEnd")
                        .HasColumnType("int");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("Domain.Core.ChatAggregate.Chat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Domain.Core.ChatAggregate.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SendedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("SenderEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Domain.Core.OrderAggregate.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientTypeClientRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Service")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientTypeClientRoleId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Core.UserAggregate.ClientRole", b =>
                {
                    b.Property<int>("ClientRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientRoleId");

                    b.ToTable("ClientRoles");

                    b.HasData(
                        new
                        {
                            ClientRoleId = 0,
                            Name = "Legal"
                        },
                        new
                        {
                            ClientRoleId = 1,
                            Name = "Person"
                        });
                });

            modelBuilder.Entity("Domain.Core.UserAggregate.SpecialistRole", b =>
                {
                    b.Property<int>("SpecialistRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecialistRoleId");

                    b.ToTable("SpecialistRoles");

                    b.HasData(
                        new
                        {
                            SpecialistRoleId = 0,
                            Name = "Specialist"
                        },
                        new
                        {
                            SpecialistRoleId = 1,
                            Name = "LeadingSpecialist"
                        },
                        new
                        {
                            SpecialistRoleId = 2,
                            Name = "TechnicalSpecialist"
                        },
                        new
                        {
                            SpecialistRoleId = 3,
                            Name = "Director"
                        });
                });

            modelBuilder.Entity("Domain.Core.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Domain.Core.UserAggregate.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserRoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserRoleId = 0,
                            Name = "Specialist"
                        },
                        new
                        {
                            UserRoleId = 1,
                            Name = "Client"
                        });
                });

            modelBuilder.Entity("UserChat", b =>
                {
                    b.Property<Guid>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ChatId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserChat");
                });

            modelBuilder.Entity("Domain.Core.UserAggregate.Client", b =>
                {
                    b.HasBaseType("Domain.Core.UserAggregate.User");

                    b.Property<int>("ClientRoleId")
                        .HasColumnType("int");

                    b.HasIndex("ClientRoleId");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("Domain.Core.UserAggregate.Specialist", b =>
                {
                    b.HasBaseType("Domain.Core.UserAggregate.User");

                    b.Property<int>("SpecialistRoleId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasIndex("SpecialistRoleId");

                    b.ToTable("Specialists", (string)null);
                });

            modelBuilder.Entity("Domain.Core.UserAggregate.Legal", b =>
                {
                    b.HasBaseType("Domain.Core.UserAggregate.Client");

                    b.Property<string>("BankAccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankIdenticationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LegalAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LegalID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PositionHeld")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Powers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("LegalEntities", (string)null);
                });

            modelBuilder.Entity("Domain.Core.UserAggregate.Person", b =>
                {
                    b.HasBaseType("Domain.Core.UserAggregate.Client");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IssuingAuthority")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidentialAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxIdentificationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Individuals", (string)null);
                });

            modelBuilder.Entity("CaseSpecialist", b =>
                {
                    b.HasOne("Domain.Core.UserAggregate.Specialist", null)
                        .WithMany()
                        .HasForeignKey("AssigneeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Core.CaseAggregate.Case", null)
                        .WithMany()
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Core.CaseAggregate.Case", b =>
                {
                    b.HasOne("Domain.Core.UserAggregate.Client", "Customer")
                        .WithMany("Cases")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Domain.Core.ChatAggregate.Message", b =>
                {
                    b.HasOne("Domain.Core.ChatAggregate.Chat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("Domain.Core.OrderAggregate.Order", b =>
                {
                    b.HasOne("Domain.Core.UserAggregate.ClientRole", "ClientType")
                        .WithMany()
                        .HasForeignKey("ClientTypeClientRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientType");
                });

            modelBuilder.Entity("Domain.Core.UserAggregate.User", b =>
                {
                    b.HasOne("Domain.Core.UserAggregate.UserRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("UserChat", b =>
                {
                    b.HasOne("Domain.Core.ChatAggregate.Chat", null)
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Core.UserAggregate.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Core.UserAggregate.Client", b =>
                {
                    b.HasOne("Domain.Core.UserAggregate.ClientRole", "ClientRole")
                        .WithMany()
                        .HasForeignKey("ClientRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Core.UserAggregate.User", null)
                        .WithOne()
                        .HasForeignKey("Domain.Core.UserAggregate.Client", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientRole");
                });

            modelBuilder.Entity("Domain.Core.UserAggregate.Specialist", b =>
                {
                    b.HasOne("Domain.Core.UserAggregate.User", null)
                        .WithOne()
                        .HasForeignKey("Domain.Core.UserAggregate.Specialist", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Core.UserAggregate.SpecialistRole", "SpecialistRole")
                        .WithMany()
                        .HasForeignKey("SpecialistRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SpecialistRole");
                });

            modelBuilder.Entity("Domain.Core.UserAggregate.Legal", b =>
                {
                    b.HasOne("Domain.Core.UserAggregate.Client", null)
                        .WithOne()
                        .HasForeignKey("Domain.Core.UserAggregate.Legal", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Core.UserAggregate.Person", b =>
                {
                    b.HasOne("Domain.Core.UserAggregate.Client", null)
                        .WithOne()
                        .HasForeignKey("Domain.Core.UserAggregate.Person", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Core.UserAggregate.Client", b =>
                {
                    b.Navigation("Cases");
                });
#pragma warning restore 612, 618
        }
    }
}
