using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CoollabTech.Infra.Data.Migrations
{
    public partial class DataLoad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var ticketStatusId_1 = Guid.NewGuid();
            var ticketStatusId_2 = Guid.NewGuid();
            var ticketStatusId_3 = Guid.NewGuid();

            migrationBuilder.InsertData(
              table: "TicketStatus",
              columns: new[] { "Id", "Name", "DateRegister" },
              values: new object[] { ticketStatusId_1, "Aberto", DateTime.Now }
            );
            migrationBuilder.InsertData(
              table: "TicketStatus",
              columns: new[] { "Id", "Name", "DateRegister" },
              values: new object[] { ticketStatusId_2, "Em andamento", DateTime.Now }
            );
            migrationBuilder.InsertData(
              table: "TicketStatus",
              columns: new[] { "Id", "Name", "DateRegister" },
              values: new object[] { ticketStatusId_3, "Encerrado", DateTime.Now }
            );
            
            ///////////////////////////////////////////////////////////////////////////////

            var serviceProviderId_1 = Guid.NewGuid();

            migrationBuilder.InsertData(
              table: "ServiceProviders",
              columns: new[] { "Id", "Name", "DateRegister" },
              values: new object[] { serviceProviderId_1, "Sabesp", DateTime.Now }
            );

            ///////////////////////////////////////////////////////////////////////////////

            var ticketTypeId_1 = Guid.NewGuid();
            var ticketTypeId_2 = Guid.NewGuid();

            migrationBuilder.InsertData(
              table: "TicketTypes",
              columns: new[] { "Id", "Name", "ServiceProviderId", "DateRegister" },
              values: new object[] { ticketTypeId_1, "Falta de água", serviceProviderId_1, DateTime.Now }
            );
            migrationBuilder.InsertData(
              table: "TicketTypes",
              columns: new[] { "Id", "Name", "ServiceProviderId", "DateRegister" },
              values: new object[] { ticketTypeId_2, "Vazamento de água", serviceProviderId_1, DateTime.Now }
            );

            ///////////////////////////////////////////////////////////////////////////////

            var ticketId_1 = Guid.NewGuid();
            var ticketId_2 = Guid.NewGuid();
            var ticketId_3 = Guid.NewGuid();

            migrationBuilder.InsertData(
              table: "Tickets",
              columns: new[] { "Id", "Description", "Localization", "TicketStatusId", "TicketTypeId", "DateRegister" },
              values: new object[] { ticketId_1, "Chamado teste 01", "Rua teste, 01", ticketStatusId_1, ticketTypeId_1, DateTime.Now }
            );
            migrationBuilder.InsertData(
              table: "Tickets",
              columns: new[] { "Id", "Description", "Localization", "TicketStatusId", "TicketTypeId", "DateRegister" },
              values: new object[] { ticketId_2, "Chamado teste 02", "Rua teste, 02", ticketStatusId_2, ticketTypeId_2, DateTime.Now }
            );
            migrationBuilder.InsertData(
              table: "Tickets",
              columns: new[] { "Id", "Description", "Localization", "TicketStatusId", "TicketTypeId", "DateRegister" },
              values: new object[] { ticketId_3, "Chamado teste 03", "Rua teste, 03", ticketStatusId_3, ticketTypeId_1, DateTime.Now }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
