using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCswitchback.Migrations
{
    public partial class UpdatingUserInfoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserComments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserInfoID = table.Column<int>(nullable: false),
                    TrailID = table.Column<int>(nullable: false),
                    UserComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserCommentsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserInfo_UserComments_UserCommentsID",
                        column: x => x.UserCommentsID,
                        principalTable: "UserComments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "UserComments",
                columns: new[] { "ID", "TrailID", "UserComment", "UserInfoID" },
                values: new object[,]
                {
                    { 1, 7013499, "My trailmates were all slow, but the trail was great.", 1 },
                    { 2, 7013499, "I don't like physical activity...", 2 },
                    { 3, 7013499, "Was much fun, has difficult. much peril. 12/10 would recommend for bamboozle.", 3 },
                    { 4, 7013499, "It was ok.", 4 },
                    { 5, 7013499, "The trail was fantastic and the views were amazing.", 5 },
                    { 6, 1, "My trailmates were all slow, but the trail was great.", 1 },
                    { 7, 1, "I don't like physical activity...", 2 },
                    { 8, 1, "Was much fun, has difficult. much peril. 12/10 would recommend for bamboozle.", 3 },
                    { 9, 1, "It was ok.", 4 },
                    { 10, 1, "The trail was fantastic and the views were amazing.", 5 }
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "ID", "FirstName", "LastName", "UserCommentsID", "UserName" },
                values: new object[,]
                {
                    { 1, "Christopher", "Morton", null, "Secret Squirrel" },
                    { 2, "Andy", "Roska", null, "Roketsu" },
                    { 3, "Ian", "Gifford", null, "Hype Man" },
                    { 4, "Tanner", "Percival", null, "TannMann" },
                    { 5, "Mike", "Kelly", null, "The Wizard" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_UserCommentsID",
                table: "UserInfo",
                column: "UserCommentsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "UserComments");
        }
    }
}
