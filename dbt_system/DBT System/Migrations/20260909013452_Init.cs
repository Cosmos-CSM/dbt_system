using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSM_System_Database_Core.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityStates",
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
                    table.PrimaryKey("PK_EntityStates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityStates_Name",
                table: "EntityStates",
                column: "Name",
                unique: true);

            // --> Populating table with base values: upserts by [Name] so existing rows (and their Ids) are
            //     never touched, preventing duplication, wrong ids or orphaned FK references.
            migrationBuilder.Sql("""
                MERGE INTO EntityStates AS target
                USING (VALUES
                    (N'Active',     N'Represents an entity currently active and in use within the ecosystem.'),
                    (N'Archived',   N'Represents an entity that has been archived and is no longer in active use.'),
                    (N'Terminated', N'Represents an entity whose lifecycle has been terminated and deleted.'),
                    (N'Disabled',   N'Represents an entity that has been disabled and is temporarily unavailable.')
                ) AS source (Name, Description)
                ON target.Name = source.Name
                WHEN MATCHED THEN
                    UPDATE SET Description = source.Description
                WHEN NOT MATCHED BY TARGET THEN
                    INSERT (Name, Description) VALUES (source.Name, source.Description);
                """);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityStates");
        }
    }
}
