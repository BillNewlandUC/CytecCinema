using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CytecCinema.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Showings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ShowingAt = table.Column<DateTime>(nullable: false),
                    MovieName = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Showings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ShowingId = table.Column<Guid>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    TicketsBought = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Showings_ShowingId",
                        column: x => x.ShowingId,
                        principalTable: "Showings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ShowingId",
                table: "Bookings",
                column: "ShowingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Showings");
        }
    }
}
