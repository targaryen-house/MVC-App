using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCswitchback.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_UserReviews_UserReviewsID",
                table: "UserInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserInfo_UserReviewsID",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "UserReviewsID",
                table: "UserInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserReviewsID",
                table: "UserInfo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_UserReviewsID",
                table: "UserInfo",
                column: "UserReviewsID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_UserReviews_UserReviewsID",
                table: "UserInfo",
                column: "UserReviewsID",
                principalTable: "UserReviews",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
