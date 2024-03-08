using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Applicazione1.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Prenotazione_IdCliente",
                table: "Prenotazione");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazione_IdCliente",
                table: "Prenotazione",
                column: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Prenotazione_IdCliente",
                table: "Prenotazione");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazione_IdCliente",
                table: "Prenotazione",
                column: "IdCliente",
                unique: true);
        }
    }
}
