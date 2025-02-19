using Microsoft.EntityFrameworkCore.Migrations;

namespace Mqeb.Infra.Data.Migrations
{
    public partial class AddBlogVideosToBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogVideos");

            migrationBuilder.AddColumn<string>(
                name: "BlogVideos",
                table: "Blogs",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogVideos",
                table: "Blogs");

            migrationBuilder.CreateTable(
                name: "BlogVideos",
                columns: table => new
                {
                    VideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogVideos", x => x.VideoId);
                    table.ForeignKey(
                        name: "FK_BlogVideos_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogVideos_BlogId",
                table: "BlogVideos",
                column: "BlogId");
        }
    }
}
