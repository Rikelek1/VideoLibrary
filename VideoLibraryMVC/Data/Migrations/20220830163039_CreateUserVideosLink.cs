using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoLibraryMVC.Data.Migrations
{
    public partial class CreateUserVideosLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserVideo",
                columns: table => new
                {
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VideosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserVideo", x => new { x.UsersId, x.VideosId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserVideo_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserVideo_Videos_VideosId",
                        column: x => x.VideosId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserVideo_VideosId",
                table: "ApplicationUserVideo",
                column: "VideosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserVideo");
        }
    }
}
