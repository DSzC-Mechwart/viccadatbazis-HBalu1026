using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViccAdatbazis.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_321 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Viccek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tartalom = table.Column<string>(type: "TEXT", nullable: false),
                    Feltolto = table.Column<string>(type: "TEXT", nullable: false),
                    Tetszik = table.Column<int>(type: "INTEGER", nullable: false),
                    NemTetszik = table.Column<int>(type: "INTEGER", nullable: false),
                    Aktiv = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viccek", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Viccek");
        }
    }
}
