using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hotel_backend.Migrations
{
    /// <inheritdoc />
    public partial class ModifyRoomTypeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeTypeId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomTypeTypeId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomTypeTypeId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Rooms",
                newName: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "RoomTypeId",
                table: "Rooms",
                newName: "TypeId");

            migrationBuilder.AddColumn<int>(
                name: "RoomTypeTypeId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeTypeId",
                table: "Rooms",
                column: "RoomTypeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeTypeId",
                table: "Rooms",
                column: "RoomTypeTypeId",
                principalTable: "RoomTypes",
                principalColumn: "TypeId");
        }
    }
}
