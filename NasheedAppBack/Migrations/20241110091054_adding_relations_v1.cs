using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NasheedAppBack.Migrations
{
    /// <inheritdoc />
    public partial class adding_relations_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NasheedPlaylists",
                columns: table => new
                {
                    PlaylistId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NasheedId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NasheedPlaylists", x => new { x.PlaylistId, x.NasheedId });
                    table.ForeignKey(
                        name: "FK_NasheedPlaylists_Nasheeds_NasheedId",
                        column: x => x.NasheedId,
                        principalTable: "Nasheeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NasheedPlaylists_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NasheedPlaylists_NasheedId",
                table: "NasheedPlaylists",
                column: "NasheedId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_UserId",
                table: "Playlists",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NasheedPlaylists");

            migrationBuilder.DropTable(
                name: "Playlists");
        }
    }
}
