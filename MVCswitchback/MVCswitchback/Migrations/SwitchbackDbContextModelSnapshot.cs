﻿// <auto-generated />
using MVCswitchback.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCswitchback.Migrations
{
    [DbContext(typeof(SwitchbackDbContext))]
    partial class SwitchbackDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
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
                            LastName = "Robin",
                            UserName = "Cmorto"
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

                    b.HasKey("ID");

                    b.ToTable("UserReviews");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            TrailID = 0,
                            UserComment = "Was much fun, has difficult. much peril. 12/10 would recommend for bamboozle",
                            UserID = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
