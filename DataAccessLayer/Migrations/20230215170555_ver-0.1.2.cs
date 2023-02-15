using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class ver012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Trips_TripId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_TripId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Images");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_TripId",
                table: "Images",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Trips_TripId",
                table: "Images",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id");
        }
    }
}
