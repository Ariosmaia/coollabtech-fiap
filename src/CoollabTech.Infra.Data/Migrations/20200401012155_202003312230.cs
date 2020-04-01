using Microsoft.EntityFrameworkCore.Migrations;

namespace CoollabTech.Infra.Data.Migrations
{
    public partial class _202003312230 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TicketTypes_ServiceProviderId",
                table: "TicketTypes",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketStatusId",
                table: "Tickets",
                column: "TicketStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketTypeId",
                table: "Tickets",
                column: "TicketTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketStatus_TicketStatusId",
                table: "Tickets",
                column: "TicketStatusId",
                principalTable: "TicketStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketTypes_TicketTypeId",
                table: "Tickets",
                column: "TicketTypeId",
                principalTable: "TicketTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTypes_ServiceProviders_ServiceProviderId",
                table: "TicketTypes",
                column: "ServiceProviderId",
                principalTable: "ServiceProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketStatus_TicketStatusId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketTypes_TicketTypeId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketTypes_ServiceProviders_ServiceProviderId",
                table: "TicketTypes");

            migrationBuilder.DropIndex(
                name: "IX_TicketTypes_ServiceProviderId",
                table: "TicketTypes");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketStatusId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketTypeId",
                table: "Tickets");
        }
    }
}
