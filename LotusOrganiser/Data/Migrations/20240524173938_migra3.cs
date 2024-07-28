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
                table: "Messages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_BusinessId",
                table: "Messages",
                column: "BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Businesses_BusinessId",
                table: "Messages",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "BusinessId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Businesses_BusinessId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_BusinessId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Messages");
        }
    }
}
