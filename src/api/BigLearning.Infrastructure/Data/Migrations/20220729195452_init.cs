using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Elang.Infrastructure.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Cards",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Translation = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    English = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ContextDescription = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardTopic",
                schema: "public",
                columns: table => new
                {
                    CardsId = table.Column<long>(type: "bigint", nullable: false),
                    TopicsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTopic", x => new { x.CardsId, x.TopicsId });
                    table.ForeignKey(
                        name: "FK_CardTopic_Cards_CardsId",
                        column: x => x.CardsId,
                        principalSchema: "public",
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardTopic_Topics_TopicsId",
                        column: x => x.TopicsId,
                        principalSchema: "public",
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardTopic_TopicsId",
                schema: "public",
                table: "CardTopic",
                column: "TopicsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardTopic",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Cards",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Topics",
                schema: "public");
        }
    }
}
