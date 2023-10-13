using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Currencies.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValCurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateString = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValCurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Valutes",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    NumCode = table.Column<int>(type: "INTEGER", nullable: false),
                    CharCode = table.Column<string>(type: "TEXT", nullable: true),
                    Nominal = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: true),
                    VunitRate = table.Column<string>(type: "TEXT", nullable: true),
                    ValCursId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valutes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Valutes_ValCurs_ValCursId",
                        column: x => x.ValCursId,
                        principalTable: "ValCurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Valutes_ValCursId",
                table: "Valutes",
                column: "ValCursId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Valutes");

            migrationBuilder.DropTable(
                name: "ValCurs");
        }
    }
}
