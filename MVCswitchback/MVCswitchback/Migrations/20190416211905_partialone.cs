using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCswitchback.Migrations
{
    public partial class partialone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserReviews",
                columns: new[] { "ID", "TrailID", "UserComment", "UserID" },
                values: new object[] { 1, 0, "Was much fun, has difficult. much peril. 12/10 would recommend for bamboozle", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserReviews",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
