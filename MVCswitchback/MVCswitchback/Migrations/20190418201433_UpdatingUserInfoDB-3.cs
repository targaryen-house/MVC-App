using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCswitchback.Migrations
{
    public partial class UpdatingUserInfoDB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserComments",
                columns: new[] { "ID", "TrailID", "UserComment", "UserInfoID" },
                values: new object[,]
                {
                    { 11, 2, "My trailmates were all slow, but the trail was great.", 1 },
                    { 12, 2, "I don't like physical activity...", 2 },
                    { 13, 3, "My trailmates were all slow, but the trail was great.", 1 },
                    { 14, 3, "I don't like physical activity...", 2 },
                    { 15, 4, "My trailmates were all slow, but the trail was great.", 1 },
                    { 16, 4, "I don't like physical activity...", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserComments",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "UserComments",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "UserComments",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "UserComments",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "UserComments",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "UserComments",
                keyColumn: "ID",
                keyValue: 16);
        }
    }
}
