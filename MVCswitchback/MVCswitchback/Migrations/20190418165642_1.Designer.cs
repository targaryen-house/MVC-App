﻿// <auto-generated />
using System;
using MVCswitchback.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCswitchback.Migrations
{
    [DbContext(typeof(SwitchbackDbContext))]
    [Migration("20190418165642_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCswitchback.Models.UserInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.ToTable("UserInfo");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            FirstName = "Christopher",
                            LastName = "Morton",
                            UserName = "Secret Squirrel"
                        },
                        new
                        {
                            ID = 2,
                            FirstName = "Andy",
                            LastName = "Roska",
                            UserName = "Roketsu"
                        },
                        new
                        {
                            ID = 3,
                            FirstName = "Ian",
                            LastName = "Gifford",
                            UserName = "Hype Man"
                        },
                        new
                        {
                            ID = 4,
                            FirstName = "Tanner",
                            LastName = "Percival",
                            UserName = "TannMann"
                        },
                        new
                        {
                            ID = 5,
                            FirstName = "Mike",
                            LastName = "Kelly",
                            UserName = "The Wizard"
                        });
                });

            modelBuilder.Entity("MVCswitchback.Models.UserReviews", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TrailID");

                    b.Property<string>("UserComment");

                    b.Property<int>("UserID");

                    b.Property<int?>("UserInfoID");

                    b.HasKey("ID");

                    b.HasIndex("UserInfoID");

                    b.ToTable("UserReviews");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            TrailID = 7013499,
                            UserComment = "My trailmates were all slow, but the trail was great.",
                            UserID = 1
                        },
                        new
                        {
                            ID = 2,
                            TrailID = 7013499,
                            UserComment = "I don't like physical activity...",
                            UserID = 2
                        },
                        new
                        {
                            ID = 3,
                            TrailID = 7013499,
                            UserComment = "Was much fun, has difficult. much peril. 12/10 would recommend for bamboozle.",
                            UserID = 3
                        },
                        new
                        {
                            ID = 4,
                            TrailID = 7013499,
                            UserComment = "It was ok.",
                            UserID = 4
                        },
                        new
                        {
                            ID = 5,
                            TrailID = 7013499,
                            UserComment = "The trail was fantastic and the views were amazing.",
                            UserID = 5
                        },
                        new
                        {
                            ID = 6,
                            TrailID = 1,
                            UserComment = "My trailmates were all slow, but the trail was great.",
                            UserID = 1
                        },
                        new
                        {
                            ID = 7,
                            TrailID = 1,
                            UserComment = "I don't like physical activity...",
                            UserID = 2
                        },
                        new
                        {
                            ID = 8,
                            TrailID = 1,
                            UserComment = "Was much fun, has difficult. much peril. 12/10 would recommend for bamboozle.",
                            UserID = 3
                        },
                        new
                        {
                            ID = 9,
                            TrailID = 1,
                            UserComment = "It was ok.",
                            UserID = 4
                        },
                        new
                        {
                            ID = 10,
                            TrailID = 1,
                            UserComment = "The trail was fantastic and the views were amazing.",
                            UserID = 5
                        });
                });

            modelBuilder.Entity("MVCswitchback.Models.UserReviews", b =>
                {
                    b.HasOne("MVCswitchback.Models.UserInfo", "UserInfo")
                        .WithMany("UserReviews")
                        .HasForeignKey("UserInfoID");
                });
#pragma warning restore 612, 618
        }
    }
}
