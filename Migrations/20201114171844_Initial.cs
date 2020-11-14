using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetMoviesAppRazor.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ReleaseYear = table.Column<int>(type: "INTEGER", nullable: false),
                    Genre = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2048, nullable: false),
                    PosterPath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 2048, nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: true),
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmReviews_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmReviews_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmUser",
                columns: table => new
                {
                    FavouriteFilmsId = table.Column<int>(type: "INTEGER", nullable: false),
                    FavouriteOfUsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmUser", x => new { x.FavouriteFilmsId, x.FavouriteOfUsersId });
                    table.ForeignKey(
                        name: "FK_FilmUser_AspNetUsers_FavouriteOfUsersId",
                        column: x => x.FavouriteOfUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmUser_Films_FavouriteFilmsId",
                        column: x => x.FavouriteFilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmPerson",
                columns: table => new
                {
                    ActoredFilmsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActorsPersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmPerson", x => new { x.ActoredFilmsId, x.ActorsPersonId });
                    table.ForeignKey(
                        name: "FK_FilmPerson_Films_ActoredFilmsId",
                        column: x => x.ActoredFilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmPerson_Persons_ActorsPersonId",
                        column: x => x.ActorsPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmPerson1",
                columns: table => new
                {
                    DirectoredFilmsId = table.Column<int>(type: "INTEGER", nullable: false),
                    DirectorsPersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmPerson1", x => new { x.DirectoredFilmsId, x.DirectorsPersonId });
                    table.ForeignKey(
                        name: "FK_FilmPerson1_Films_DirectoredFilmsId",
                        column: x => x.DirectoredFilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmPerson1_Persons_DirectorsPersonId",
                        column: x => x.DirectorsPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "Genre", "PosterPath", "ReleaseYear", "Title" },
                values: new object[] { 1, "A description of \"Game of Thrones\"", 5, "/img/posters/1.jpeg", 2011, "Game of Thrones" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "Genre", "PosterPath", "ReleaseYear", "Title" },
                values: new object[] { 2, "A description of \"The Mask\"", 3, "/img/posters/2.jpg", 1994, "The Mask" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "Genre", "PosterPath", "ReleaseYear", "Title" },
                values: new object[] { 3, "A description of \"The Shawshank Redemption\"", 6, "/img/posters/3.jpg", 1994, "The Shawshank Redemption" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "Genre", "PosterPath", "ReleaseYear", "Title" },
                values: new object[] { 4, "A description of \"Léon: The Professional\"", 6, "/img/posters/4.jpg", 1994, "Léon: The Professional" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "Genre", "PosterPath", "ReleaseYear", "Title" },
                values: new object[] { 5, "A description of \"Sherlock\"", 7, "/img/posters/5.jpg", 2010, "Sherlock" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "Genre", "PosterPath", "ReleaseYear", "Title" },
                values: new object[] { 6, "A description of \"Intouchables\"", 6, "/img/posters/6.jpg", 2011, "Intouchables" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "Genre", "PosterPath", "ReleaseYear", "Title" },
                values: new object[] { 7, "A description of \"Back to the Future\"", 8, "/img/posters/7.jpg", 1985, "Back to the Future" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 19, "Robert Zemeckis" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 18, "Omar Sy" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 17, "François Cluzet" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 16, "Olivier Nakache" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 15, "Martin Freeman" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 14, "Benedict Cumberbatch" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 13, "Paul McGuigan" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 12, "Jean Reno" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 11, "Natalie Portman" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 7, "Frank Darabont" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 9, "Morgan Freeman" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 8, "Tim Robbins" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 20, "Michael J. Fox" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 6, "Peter Riegert" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 5, "Jim Carrey" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 4, "Chuck Russell" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 3, "Sean Bean" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 2, "Peter Hayden Dinklage" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 1, "Alan Taylor" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 10, "Luc Besson" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name" },
                values: new object[] { 21, "Christopher Lloyd" });

            migrationBuilder.InsertData(
                table: "FilmPerson",
                columns: new[] { "ActoredFilmsId", "ActorsPersonId" },
                values: new object[] { 4, 11 });

            migrationBuilder.InsertData(
                table: "FilmPerson",
                columns: new[] { "ActoredFilmsId", "ActorsPersonId" },
                values: new object[] { 6, 18 });

            migrationBuilder.InsertData(
                table: "FilmPerson",
                columns: new[] { "ActoredFilmsId", "ActorsPersonId" },
                values: new object[] { 6, 17 });

            migrationBuilder.InsertData(
                table: "FilmPerson",
                columns: new[] { "ActoredFilmsId", "ActorsPersonId" },
                values: new object[] { 5, 15 });

            migrationBuilder.InsertData(
                table: "FilmPerson",
                columns: new[] { "ActoredFilmsId", "ActorsPersonId" },
                values: new object[] { 5, 14 });

            migrationBuilder.InsertData(
                table: "FilmPerson",
                columns: new[] { "ActoredFilmsId", "ActorsPersonId" },
                values: new object[] { 4, 12 });

            migrationBuilder.InsertData(
                table: "FilmPerson",
                columns: new[] { "ActoredFilmsId", "ActorsPersonId" },
                values: new object[] { 7, 20 });

            migrationBuilder.InsertData(
                table: "FilmPerson",
                columns: new[] { "ActoredFilmsId", "ActorsPersonId" },
                values: new object[] { 3, 9 });

            migrationBuilder.InsertData(
                table: "FilmPerson",
                columns: new[] { "ActoredFilmsId", "ActorsPersonId" },
                values: new object[] { 7, 21 });

            migrationBuilder.InsertData(
                table: "FilmPerson",
                columns: new[] { "ActoredFilmsId", "ActorsPersonId" },
                values: new object[] { 2, 6 });

            migrationBuilder.InsertData(
                table: "FilmPerson",
                columns: new[] { "ActoredFilmsId", "ActorsPersonId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "FilmPerson",
                columns: new[] { "ActoredFilmsId", "ActorsPersonId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "FilmPerson",
                columns: new[] { "ActoredFilmsId", "ActorsPersonId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "FilmPerson",
                columns: new[] { "ActoredFilmsId", "ActorsPersonId" },
                values: new object[] { 3, 8 });

            migrationBuilder.InsertData(
                table: "FilmPerson1",
                columns: new[] { "DirectoredFilmsId", "DirectorsPersonId" },
                values: new object[] { 4, 10 });

            migrationBuilder.InsertData(
                table: "FilmPerson1",
                columns: new[] { "DirectoredFilmsId", "DirectorsPersonId" },
                values: new object[] { 3, 7 });

            migrationBuilder.InsertData(
                table: "FilmPerson1",
                columns: new[] { "DirectoredFilmsId", "DirectorsPersonId" },
                values: new object[] { 5, 13 });

            migrationBuilder.InsertData(
                table: "FilmPerson1",
                columns: new[] { "DirectoredFilmsId", "DirectorsPersonId" },
                values: new object[] { 2, 4 });

            migrationBuilder.InsertData(
                table: "FilmPerson1",
                columns: new[] { "DirectoredFilmsId", "DirectorsPersonId" },
                values: new object[] { 6, 16 });

            migrationBuilder.InsertData(
                table: "FilmPerson1",
                columns: new[] { "DirectoredFilmsId", "DirectorsPersonId" },
                values: new object[] { 7, 19 });

            migrationBuilder.InsertData(
                table: "FilmPerson1",
                columns: new[] { "DirectoredFilmsId", "DirectorsPersonId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilmPerson_ActorsPersonId",
                table: "FilmPerson",
                column: "ActorsPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmPerson1_DirectorsPersonId",
                table: "FilmPerson1",
                column: "DirectorsPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmReviews_AuthorId",
                table: "FilmReviews",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmReviews_FilmId",
                table: "FilmReviews",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmUser_FavouriteOfUsersId",
                table: "FilmUser",
                column: "FavouriteOfUsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FilmPerson");

            migrationBuilder.DropTable(
                name: "FilmPerson1");

            migrationBuilder.DropTable(
                name: "FilmReviews");

            migrationBuilder.DropTable(
                name: "FilmUser");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}
