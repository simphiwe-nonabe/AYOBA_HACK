using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LotusOrganiser.Migrations
{
    /// <inheritdoc />
    public partial class migra1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BusinessId",
                table: "Subscriptions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_BusinessId",
                table: "Subscriptions",
                column: "BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Businesses_BusinessId",
                table: "Subscriptions",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "BusinessId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Businesses_BusinessId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_BusinessId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Subscriptions");
        }
    }
}
