using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorStore.Data.Migrations
{
    public partial class Initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCategory_BlogTag_BlogTagId",
                table: "PostCategory");

            migrationBuilder.DropIndex(
                name: "IX_PostCategory_BlogTagId",
                table: "PostCategory");

            migrationBuilder.DropColumn(
                name: "BlogTagId",
                table: "PostCategory");

            migrationBuilder.CreateTable(
                name: "BlogPostBlogTag",
                columns: table => new
                {
                    BlogTagsId = table.Column<int>(type: "integer", nullable: false),
                    PostCategoriesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostBlogTag", x => new { x.BlogTagsId, x.PostCategoriesId });
                    table.ForeignKey(
                        name: "FK_BlogPostBlogTag_BlogTag_BlogTagsId",
                        column: x => x.BlogTagsId,
                        principalTable: "BlogTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPostBlogTag_PostCategory_PostCategoriesId",
                        column: x => x.PostCategoriesId,
                        principalTable: "PostCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostBlogTag_PostCategoriesId",
                table: "BlogPostBlogTag",
                column: "PostCategoriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostBlogTag");

            migrationBuilder.AddColumn<int>(
                name: "BlogTagId",
                table: "PostCategory",
                type: "integer",
                nullable: true);

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
    }
}
