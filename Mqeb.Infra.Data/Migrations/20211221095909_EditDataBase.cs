using Microsoft.EntityFrameworkCore.Migrations;

namespace Mqeb.Infra.Data.Migrations
{
    public partial class EditDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogGallery_Blogs_BlogId",
                table: "BlogGallery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogGallery",
                table: "BlogGallery");

            migrationBuilder.RenameTable(
                name: "BlogGallery",
                newName: "BlogGalleries");

            migrationBuilder.RenameIndex(
                name: "IX_BlogGallery_BlogId",
                table: "BlogGalleries",
                newName: "IX_BlogGalleries_BlogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogGalleries",
                table: "BlogGalleries",
                column: "BlogGalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogGalleries_Blogs_BlogId",
                table: "BlogGalleries",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogGalleries_Blogs_BlogId",
                table: "BlogGalleries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogGalleries",
                table: "BlogGalleries");

            migrationBuilder.RenameTable(
                name: "BlogGalleries",
                newName: "BlogGallery");

            migrationBuilder.RenameIndex(
                name: "IX_BlogGalleries_BlogId",
                table: "BlogGallery",
                newName: "IX_BlogGallery_BlogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogGallery",
                table: "BlogGallery",
                column: "BlogGalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogGallery_Blogs_BlogId",
                table: "BlogGallery",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
