using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCswitchback.Migrations
{
    public partial class UpdatingUserInfoDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_UserComments_UserCommentsID",
                table: "UserInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserInfo_UserCommentsID",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "UserCommentsID",
                table: "UserInfo");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_UserInfoID",
                table: "UserComments",
                column: "UserInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_UserInfo_UserInfoID",
                table: "UserComments",
                column: "UserInfoID",
                principalTable: "UserInfo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_UserInfo_UserInfoID",
                table: "UserComments");

            migrationBuilder.DropIndex(
                name: "IX_UserComments_UserInfoID",
                table: "UserComments");

            migrationBuilder.AddColumn<int>(
                name: "UserCommentsID",
                table: "UserInfo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_UserCommentsID",
                table: "UserInfo",
                column: "UserCommentsID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_UserComments_UserCommentsID",
                table: "UserInfo",
                column: "UserCommentsID",
                principalTable: "UserComments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
