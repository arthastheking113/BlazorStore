using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BlazorStore.Data.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Abstract = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsproductionReady = table.Column<bool>(type: "boolean", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    ImageData = table.Column<byte[]>(type: "bytea", nullable: true),
                    ContentType = table.Column<string>(type: "text", nullable: true),
                    ViewCount = table.Column<int>(type: "integer", nullable: false),
                    BlogCategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostCategory_BlogCategory_BlogCategoryId",
                        column: x => x.BlogCategoryId,
                        principalTable: "BlogCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: true),
                    CommentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Update = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsModerated = table.Column<bool>(type: "boolean", nullable: false),
                    Moderated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModeratedReason = table.Column<string>(type: "text", nullable: true),
                    ModeratedContent = table.Column<string>(type: "text", nullable: true),
                    PostCategoryId = table.Column<int>(type: "integer", nullable: false),
                    CustomUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostComment_AspNetUsers_CustomUserId",
                        column: x => x.CustomUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostComment_PostCategory_PostCategoryId",
                        column: x => x.PostCategoryId,
                        principalTable: "PostCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostCategory_BlogCategoryId",
                table: "PostCategory",
                column: "BlogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_CustomUserId",
                table: "PostComment",
                column: "CustomUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_PostCategoryId",
                table: "PostComment",
                column: "PostCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostComment");

            migrationBuilder.DropTable(
                name: "PostCategory");

            migrationBuilder.DropTable(
                name: "BlogCategory");
        }
    }
}
