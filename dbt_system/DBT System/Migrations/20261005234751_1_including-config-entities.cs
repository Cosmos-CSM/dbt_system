using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSM_System_Database_Core.Migrations
{
    /// <inheritdoc />
    public partial class _1_includingconfigentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsArray = table.Column<bool>(type: "bit", nullable: false),
                    ValueReferenceType = table.Column<int>(type: "int", nullable: false),
                    ScalarValueType = table.Column<int>(type: "int", nullable: true),
                    ReferenceValueType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    External = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<long>(type: "bigint", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Assets_Type",
                        column: x => x.Type,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Name",
                table: "Assets",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_Name",
                table: "Configurations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resources_Name",
                table: "Resources",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resources_Type",
                table: "Resources",
                column: "Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Assets");
        }
    }
}
