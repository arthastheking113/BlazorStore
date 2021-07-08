using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BlazorStore.Data.Migrations
{
    public partial class Initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "PostCategory",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "PostCategory",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Abstract",
                table: "PostCategory",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlogTagId",
                table: "PostCategory",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BlogTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TagName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTag", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostCategory_BlogTagId",
                table: "PostCategory",
                column: "BlogTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategory_BlogTag_BlogTagId",
                table: "PostCategory",
                column: "BlogTagId",
                principalTable: "BlogTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCategory_BlogTag_BlogTagId",
                table: "PostCategory");

            migrationBuilder.DropTable(
                name: "BlogTag");

            migrationBuilder.DropIndex(
                name: "IX_PostCategory_BlogTagId",
                table: "PostCategory");

            migrationBuilder.DropColumn(
                name: "BlogTagId",
                table: "PostCategory");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "PostCategory",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "PostCategory",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Abstract",
                table: "PostCategory",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
