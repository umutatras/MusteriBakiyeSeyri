using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusteriBakiyeSeyri.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "musteri_tanim_table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UNVAN = table.Column<string>(type: "char(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musteri_tanim_table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "musteri_fatura_table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    fatura_tarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    fatura_tutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    odeme_tarihi = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musteri_fatura_table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_musteri_fatura_table_musteri_tanim_table_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "musteri_tanim_table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_musteri_fatura_table_Id",
                table: "musteri_fatura_table",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_musteri_fatura_table_MusteriId",
                table: "musteri_fatura_table",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_musteri_tanim_table_Id",
                table: "musteri_tanim_table",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "musteri_fatura_table");

            migrationBuilder.DropTable(
                name: "musteri_tanim_table");
        }
    }
}
