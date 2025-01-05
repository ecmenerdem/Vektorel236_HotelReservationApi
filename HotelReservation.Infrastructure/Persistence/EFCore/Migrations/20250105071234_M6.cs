using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.Infrastructure.Persistence.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class M6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupID",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    AddedUser = table.Column<int>(type: "int", nullable: true),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddedIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedUser = table.Column<int>(type: "int", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedIP = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_GroupID",
                table: "User",
                column: "GroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserGroup_GroupID",
                table: "User",
                column: "GroupID",
                principalTable: "UserGroup",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserGroup_GroupID",
                table: "User");

            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropIndex(
                name: "IX_User_GroupID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GroupID",
                table: "User");
        }
    }
}
