using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LotusOrganiser.Migrations
{
    /// <inheritdoc />
    public partial class messageCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "ToDoListItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoListItems_UserId",
                table: "ToDoListItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoListItems_Users_UserId",
                table: "ToDoListItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoListItems_Users_UserId",
                table: "ToDoListItems");

            migrationBuilder.DropIndex(
                name: "IX_ToDoListItems_UserId",
                table: "ToDoListItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ToDoListItems");
        }
    }
}
