using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCswitchback.Migrations
{
    public partial class TestingNewNavPropsAgain : Migration
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
