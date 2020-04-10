using Microsoft.EntityFrameworkCore.Migrations;

namespace CouponTrackerWebsite.Data.Migrations
{
    public partial class temporary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_coupon_AspNetUsers_userSubmissionId",
            //    table: "coupon");

            //migrationBuilder.DropIndex(
            //    name: "IX_coupon_userSubmissionId",
            //    table: "coupon");

            //migrationBuilder.RenameColumn(
            //    name: "userSubmissionId",
            //    table: "coupon",
            //    newName: "userSubmission");

            //migrationBuilder.AlterColumn<string>(
            //    name: "userSubmission",
            //    table: "coupon",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldNullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "category",
            //    table: "coupon",
            //    nullable: false,
            //    defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "coupon");

            migrationBuilder.RenameColumn(
                name: "userSubmission",
                table: "coupon",
                newName: "userSubmissionId");

            migrationBuilder.AlterColumn<string>(
                name: "userSubmissionId",
                table: "coupon",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_coupon_userSubmissionId",
                table: "coupon",
                column: "userSubmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_coupon_AspNetUsers_userSubmissionId",
                table: "coupon",
                column: "userSubmissionId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
