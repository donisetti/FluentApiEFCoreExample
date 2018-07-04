using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FluentApiEFCoreExample.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                columns: table => new
                {
                    UId = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    UId = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 45, nullable: false),
                    Email = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "ARTICLES",
                columns: table => new
                {
                    UId = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 120, nullable: false),
                    Body = table.Column<string>(nullable: false),
                    UserUId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTICLES", x => x.UId);
                    table.ForeignKey(
                        name: "FK_ARTICLES_USERS_UserUId",
                        column: x => x.UserUId,
                        principalTable: "USERS",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ARTICLES_CATEGORIES",
                columns: table => new
                {
                    UId = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    CategoryUId = table.Column<string>(nullable: false),
                    ArticleUId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTICLES_CATEGORIES", x => x.UId);
                    table.ForeignKey(
                        name: "FK_ARTICLES_CATEGORIES_ARTICLES_ArticleUId",
                        column: x => x.ArticleUId,
                        principalTable: "ARTICLES",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ARTICLES_CATEGORIES_CATEGORIES_CategoryUId",
                        column: x => x.CategoryUId,
                        principalTable: "CATEGORIES",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ARTICLES_Title",
                table: "ARTICLES",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ARTICLES_UserUId",
                table: "ARTICLES",
                column: "UserUId");

            migrationBuilder.CreateIndex(
                name: "IX_ARTICLES_CATEGORIES_ArticleUId",
                table: "ARTICLES_CATEGORIES",
                column: "ArticleUId");

            migrationBuilder.CreateIndex(
                name: "IX_ARTICLES_CATEGORIES_CategoryUId",
                table: "ARTICLES_CATEGORIES",
                column: "CategoryUId");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIES_Name",
                table: "CATEGORIES",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERS_Email",
                table: "USERS",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ARTICLES_CATEGORIES");

            migrationBuilder.DropTable(
                name: "ARTICLES");

            migrationBuilder.DropTable(
                name: "CATEGORIES");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
