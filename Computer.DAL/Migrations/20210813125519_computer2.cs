using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Computer.DAL.Migrations
{
    public partial class computer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pcs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PcUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PcId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PcUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PcUsers_Pcs_PcId",
                        column: x => x.PcId,
                        principalTable: "Pcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PcUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PcUsers_PcId",
                table: "PcUsers",
                column: "PcId");

            migrationBuilder.CreateIndex(
                name: "IX_PcUsers_UserId",
                table: "PcUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PcUsers");

            migrationBuilder.DropTable(
                name: "Pcs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
