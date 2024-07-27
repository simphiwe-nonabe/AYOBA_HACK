using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LotusOrganiser.Migrations
{
    /// <inheritdoc />
    public partial class migra3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BusinessId",
                table: "ToDoListItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoListItems_BusinessId",
                table: "ToDoListItems",
                column: "BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoListItems_Businesses_BusinessId",
                table: "ToDoListItems",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "BusinessId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoListItems_Businesses_BusinessId",
                table: "ToDoListItems");

            migrationBuilder.DropIndex(
                name: "IX_ToDoListItems_BusinessId",
                table: "ToDoListItems");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "ToDoListItems");
        }
    }
}
