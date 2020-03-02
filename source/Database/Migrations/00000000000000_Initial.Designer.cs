// <auto-generated />
using System;
using Architecture.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Architecture.Database.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("00000000000000_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Architecture.Domain.AuthEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("Roles")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Auths","Auth");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Login = "admin",
                            Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                            Roles = 3,
                            Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9"
                        });
                });

            modelBuilder.Entity("Architecture.Domain.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AuthId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthId");

                    b.ToTable("Users","User");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AuthId = 1L,
                            Status = 1
                        });
                });

            modelBuilder.Entity("Architecture.Domain.UserEntity", b =>
                {
                    b.HasOne("Architecture.Domain.AuthEntity", "Auth")
                        .WithMany()
                        .HasForeignKey("AuthId");

                    b.OwnsOne("Architecture.Domain.Email", "Email", b1 =>
                        {
                            b1.Property<long>("UserEntityId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(300)")
                                .HasMaxLength(300);

                            b1.HasKey("UserEntityId");

                            b1.HasIndex("Address")
                                .IsUnique()
                                .HasFilter("[Email_Address] IS NOT NULL");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserEntityId");

                            b1.HasData(
                                new
                                {
                                    UserEntityId = 1L,
                                    Address = "administrator@administrator.com"
                                });
                        });

                    b.OwnsOne("Architecture.Domain.FullName", "FullName", b1 =>
                        {
                            b1.Property<long>("UserEntityId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Surname")
                                .IsRequired()
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.HasKey("UserEntityId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserEntityId");

                            b1.HasData(
                                new
                                {
                                    UserEntityId = 1L,
                                    Name = "Administrator",
                                    Surname = "Administrator"
                                });
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
