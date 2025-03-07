using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColorPalette.Migrations
{
    /// <inheritdoc />
    public partial class createDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColorModels",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HexCode = table.Column<string>(type: "varchar(7)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Desciption = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorModels", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "PaletteThemes",
                columns: table => new
                {
                    ThemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaletteThemes", x => x.ThemeId);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "PaletteModels",
                columns: table => new
                {
                    PaletteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThemeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaletteModels", x => x.PaletteId);
                    table.ForeignKey(
                        name: "FK_PaletteModels_PaletteThemes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "PaletteThemes",
                        principalColumn: "ThemeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaletteColors",
                columns: table => new
                {
                    ColorModelId = table.Column<int>(type: "int", nullable: false),
                    PaletteModelId = table.Column<int>(type: "int", nullable: false),
                    ColorOrder = table.Column<byte>(type: "tinyint", nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaletteColors", x => new { x.ColorModelId, x.PaletteModelId });
                    table.ForeignKey(
                        name: "FK_PaletteColors_ColorModels_ColorModelId",
                        column: x => x.ColorModelId,
                        principalTable: "ColorModels",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaletteColors_PaletteModels_PaletteModelId",
                        column: x => x.PaletteModelId,
                        principalTable: "PaletteModels",
                        principalColumn: "PaletteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaletteTag",
                columns: table => new
                {
                    PaletteModelId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaletteTag", x => new { x.PaletteModelId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PaletteTag_PaletteModels_PaletteModelId",
                        column: x => x.PaletteModelId,
                        principalTable: "PaletteModels",
                        principalColumn: "PaletteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaletteTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorModels_HexCode",
                table: "ColorModels",
                column: "HexCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaletteColors_PaletteModelId",
                table: "PaletteColors",
                column: "PaletteModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PaletteModels_ThemeId",
                table: "PaletteModels",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaletteTag_TagId",
                table: "PaletteTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_PaletteThemes_Name",
                table: "PaletteThemes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Name",
                table: "Tag",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaletteColors");

            migrationBuilder.DropTable(
                name: "PaletteTag");

            migrationBuilder.DropTable(
                name: "ColorModels");

            migrationBuilder.DropTable(
                name: "PaletteModels");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "PaletteThemes");
        }
    }
}
