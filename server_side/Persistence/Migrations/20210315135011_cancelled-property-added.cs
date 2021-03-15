using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
  public partial class cancelledpropertyadded : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_ActivityAttendees_Activities_ApctivityId",
          table: "ActivityAttendees");

      migrationBuilder.RenameColumn(
          name: "ApctivityId",
          table: "ActivityAttendees",
          newName: "ActivityId");

      migrationBuilder.RenameIndex(
          name: "IX_ActivityAttendees_ApctivityId",
          table: "ActivityAttendees",
          newName: "IX_ActivityAttendees_ActivityId");

      migrationBuilder.AddColumn<bool>(
          name: "IsCancelled",
          table: "Activities",
          type: "INTEGER",
          nullable: false,
          defaultValue: false);

      migrationBuilder.AddForeignKey(
          name: "FK_ActivityAttendees_Activities_ActivityId",
          table: "ActivityAttendees",
          column: "ActivityId",
          principalTable: "Activities",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_ActivityAttendees_Activities_ActivityId",
          table: "ActivityAttendees");

      migrationBuilder.DropColumn(
          name: "IsCancelled",
          table: "Activities");

      migrationBuilder.RenameColumn(
          name: "ActivityId",
          table: "ActivityAttendees",
          newName: "ApctivityId");

      migrationBuilder.RenameIndex(
          name: "IX_ActivityAttendees_ActivityId",
          table: "ActivityAttendees",
          newName: "IX_ActivityAttendees_ApctivityId");

      migrationBuilder.AddForeignKey(
          name: "FK_ActivityAttendees_Activities_ApctivityId",
          table: "ActivityAttendees",
          column: "ApctivityId",
          principalTable: "Activities",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);
    }
  }
}
