using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCswitchback.Migrations
{
    public partial class UpdateSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserInfo",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "LastName", "UserName" },
                values: new object[] { "Morton", "Secret Squirrel" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "ID", "FirstName", "LastName", "UserName" },
                values: new object[,]
                {
                    { 2, "Andy", "Roska", "Roketsu" },
                    { 3, "Ian", "Gifford", "Hype Man" },
                    { 4, "Tanner", "Percival", "TannMann" },
                    { 5, "Mike", "Kelly", "The Wizard" }
                });

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "TrailID", "UserComment" },
                values: new object[] { 7013499, "My trailmates were all slow, but the trail was great." });

            migrationBuilder.InsertData(
                table: "UserReviews",
                columns: new[] { "ID", "TrailID", "UserComment", "UserID" },
                values: new object[,]
                {
                    { 2, 7013499, "I don't like physical activity...", 2 },
                    { 3, 7013499, "Was much fun, has difficult. much peril. 12/10 would recommend for bamboozle.", 3 },
                    { 4, 7013499, "It was ok.", 4 },
                    { 5, 7013499, "The trail was fantastic and the views were amazing.", 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserReviews",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserReviews",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserReviews",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserReviews",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "UserInfo",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "LastName", "UserName" },
                values: new object[] { "Robin", "Cmorto" });

            migrationBuilder.UpdateData(
                table: "UserReviews",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "TrailID", "UserComment" },
                values: new object[] { 0, "Was much fun, has difficult. much peril. 12/10 would recommend for bamboozle" });
        }
    }
}
