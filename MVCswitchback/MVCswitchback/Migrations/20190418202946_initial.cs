using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCswitchback.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.ID);
                });

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
                    table.ForeignKey(
                        name: "FK_UserComments_UserInfo_UserInfoID",
                        column: x => x.UserInfoID,
                        principalTable: "UserInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "ID", "FirstName", "LastName", "UserName" },
                values: new object[,]
                {
                    { 1, "Christopher", "Morton", "Secret Squirrel" },
                    { 2, "Andy", "Roska", "Roketsu" },
                    { 3, "Ian", "Gifford", "Hype Man" },
                    { 4, "Tanner", "Percival", "TannMann" },
                    { 5, "Mike", "Kelly", "The Wizard" }
                });

            migrationBuilder.InsertData(
                table: "UserComments",
                columns: new[] { "ID", "TrailID", "UserComment", "UserInfoID" },
                values: new object[,]
                {
                    { 1, 7013499, "My trailmates were all slow, but the trail was great.", 1 },
                    { 6, 1, "My trailmates were all slow, but the trail was great.", 1 },
                    { 11, 2, "My trailmates were all slow, but the trail was great.", 1 },
                    { 13, 3, "My trailmates were all slow, but the trail was great.", 1 },
                    { 15, 4, "My trailmates were all slow, but the trail was great.", 1 },
                    { 2, 7013499, "I don't like physical activity...", 2 },
                    { 7, 1, "I don't like physical activity...", 2 },
                    { 12, 2, "I don't like physical activity...", 2 },
                    { 14, 3, "I don't like physical activity...", 2 },
                    { 16, 4, "I don't like physical activity...", 2 },
                    { 3, 7013499, "Was much fun, has difficult. much peril. 12/10 would recommend for bamboozle.", 3 },
                    { 8, 1, "Was much fun, has difficult. much peril. 12/10 would recommend for bamboozle.", 3 },
                    { 4, 7013499, "It was ok.", 4 },
                    { 9, 1, "It was ok.", 4 },
                    { 5, 7013499, "The trail was fantastic and the views were amazing.", 5 },
                    { 10, 1, "The trail was fantastic and the views were amazing.", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_UserInfoID",
                table: "UserComments",
                column: "UserInfoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserComments");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
