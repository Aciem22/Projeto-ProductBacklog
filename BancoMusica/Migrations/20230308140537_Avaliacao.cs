using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoMusica.Migrations
{
    /// <inheritdoc />
    public partial class Avaliacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avaliacao",
                table: "Musica",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Musica",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avaliacao",
                table: "Musica");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "Musica");
        }
    }
}
