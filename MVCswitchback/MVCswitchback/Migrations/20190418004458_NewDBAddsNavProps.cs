using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCswitchback.Migrations
{
    public partial class NewDBAddsNavProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserInfoID",
                table: "UserReviews",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_UserInfoID",
                table: "UserReviews",
                column: "UserInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_UserInfo_UserInfoID",
                table: "UserReviews",
                column: "UserInfoID",
                principalTable: "UserInfo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_UserInfo_UserInfoID",
                table: "UserReviews");

            migrationBuilder.DropIndex(
                name: "IX_UserReviews_UserInfoID",
                table: "UserReviews");

            migrationBuilder.DropColumn(
                name: "UserInfoID",
                table: "UserReviews");
        }
    }
}
