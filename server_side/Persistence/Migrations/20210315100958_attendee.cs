using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
  public partial class attendee : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "ActivityAttendees",
          columns: table => new
          {
            AppUserId = table.Column<string>(type: "TEXT", nullable: false),
            ApctivityId = table.Column<Guid>(type: "TEXT", nullable: false),
            IsHost = table.Column<bool>(type: "INTEGER", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ActivityAttendees", x => new { x.AppUserId, x.ApctivityId });
            table.ForeignKey(
                      name: "FK_ActivityAttendees_Activities_ApctivityId",
                      column: x => x.ApctivityId,
                      principalTable: "Activities",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_ActivityAttendees_AspNetUsers_AppUserId",
                      column: x => x.AppUserId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_ActivityAttendees_ApctivityId",
          table: "ActivityAttendees",
          column: "ApctivityId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "ActivityAttendees");
    }
  }
}
