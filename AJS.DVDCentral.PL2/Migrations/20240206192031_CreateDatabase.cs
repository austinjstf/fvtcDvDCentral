using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AJS.DVDCentral.PL2.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCustomer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ZIP = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomer_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblDirector",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDirector_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFormat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFormat_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblGenre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGenre_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRating_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Password = table.Column<string>(type: "varchar(28)", unicode: false, maxLength: 28, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrder_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblOrder_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "tblCustomer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblMovie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    FormatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMovie_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblMovie_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "tblDirector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblMovie_FormatId",
                        column: x => x.FormatId,
                        principalTable: "tblFormat",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblMovie_RatingId",
                        column: x => x.RatingId,
                        principalTable: "tblRating",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblCart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCart_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMovieGenre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMovieGenre_Id", x => x.Id);
                    table.ForeignKey(
                        name: "tblMovieGenre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "tblGenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "tblMovieGenre_MovieId",
                        column: x => x.MovieId,
                        principalTable: "tblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblOrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrderItem_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblOrderItem_tblMovie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "tblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tblOrderItem_OrderId",
                        column: x => x.OrderId,
                        principalTable: "tblOrder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblCartItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCartItem_tblCart_CartId",
                        column: x => x.CartId,
                        principalTable: "tblCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCartItem_tblMovie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "tblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblCustomer",
                columns: new[] { "Id", "Address", "City", "FirstName", "LastName", "Phone", "State", "UserId", "ZIP" },
                values: new object[,]
                {
                    { new Guid("5eefe923-6e61-459c-a985-5859a07cac42"), "159 Johnson Avenue", "Allenton", "Brian", "Foote", "9202623415", "WI", new Guid("1e1e7a85-fa7a-46e1-8ce5-a6ffef1cd237"), "53142" },
                    { new Guid("6c8c03c5-56ef-46e8-9d61-926db7bc6987"), "987 Willow Road", "Slinger", "John", "Doro", "9202623345", "WI", new Guid("6a555dc1-12a3-485e-89c3-a1966b96cefd"), "56495" },
                    { new Guid("7820d137-4a88-4fa3-bb38-792e0c392597"), "453 Oak Street", "Fond du Lac", "Steve", "Marin", "9205879797", "WI", new Guid("7a1192b7-66f7-4cb6-86e8-69ddcd23ed1d"), "54935" }
                });

            migrationBuilder.InsertData(
                table: "tblDirector",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("4f529afc-ca05-4ce0-abac-d0d6a50f2632"), "George", "Lucas" },
                    { new Guid("594a5d2e-93ee-4a5f-bbdc-b1567b4f4581"), "Clint", "Eastwood" },
                    { new Guid("64f3a8c2-c4c4-4de1-984f-f1b833c42adb"), "John", "Avildsen" },
                    { new Guid("9254a774-f57d-40c5-ac0e-ac75b1a39b28"), "Rob", "Reiner" },
                    { new Guid("ae4da4d2-1e9c-4183-a843-f3b029b3a65b"), "Other", "Other" },
                    { new Guid("ca0b1c64-4a73-43c7-99fd-58d587c42d4a"), "Steven", "Spielberg" }
                });

            migrationBuilder.InsertData(
                table: "tblFormat",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("82b46941-0e5d-46a3-8f40-a9e91536f458"), "VHS" },
                    { new Guid("8cb86598-7753-47f5-8d21-c8d826672e31"), "Blu-Ray" },
                    { new Guid("abd0dbf7-beae-4053-9e36-d3fb4798ba1b"), "Other" },
                    { new Guid("fb110472-8dad-44e7-ba69-48c87b45705f"), "DVD" }
                });

            migrationBuilder.InsertData(
                table: "tblGenre",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("005e4e0b-0c72-4bd3-8c72-94641fb6f2b0"), "Mystery" },
                    { new Guid("0ee2675d-85a7-43dc-8156-9bdea6faaa81"), "Musical" },
                    { new Guid("1122a214-a3ef-4781-8983-b8a5657e5305"), "Action" },
                    { new Guid("39306760-9db8-4571-99c5-9650aa4666f5"), "Comedy" },
                    { new Guid("41e9c411-d9ed-4d10-ba8a-e2081e4fd0fd"), "Sci-Fi" },
                    { new Guid("5b8fdf16-edb0-4940-970f-31b6bc3f99b0"), "Documentary" },
                    { new Guid("ba38b0b9-d118-4047-9fa9-a1a3236602b0"), "Romance" },
                    { new Guid("bc9500b5-9f7f-41d2-8e37-0794ef19243b"), "Other" },
                    { new Guid("e08fc682-701c-4749-9311-db3572bdd1a7"), "Horror" },
                    { new Guid("eafd0a37-a1fc-4456-bcc3-a4e877ddc326"), "Western" }
                });

            migrationBuilder.InsertData(
                table: "tblRating",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("00ea341c-1e83-48d2-beee-cd54faa7ef3d"), "R" },
                    { new Guid("0df62934-4eaa-4f02-b644-5995ff9207c2"), "G" },
                    { new Guid("236f43c1-6c28-4f4a-ae87-7c6ae52a63f1"), "PG" },
                    { new Guid("32c8a5fd-d63d-4e5d-92e4-192bf71f1287"), "Other" },
                    { new Guid("60292baa-fe54-43b5-b943-bb12d859b088"), "PG-13" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("1e1e7a85-fa7a-46e1-8ce5-a6ffef1cd237"), "Brian", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "bfoote" },
                    { new Guid("39183c4a-9cb7-41ae-a660-0585099b6461"), "Other", "Other", "X1BEO/529yeajg8vCpiXXNv/OOk=", "sophie" },
                    { new Guid("6a555dc1-12a3-485e-89c3-a1966b96cefd"), "John", "Doro", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "jdoro" },
                    { new Guid("7a1192b7-66f7-4cb6-86e8-69ddcd23ed1d"), "Steve", "Marin", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "smarin" }
                });

            migrationBuilder.InsertData(
                table: "tblCart",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("990e4962-0cab-437b-a56f-5320f9d78776"), new Guid("7a1192b7-66f7-4cb6-86e8-69ddcd23ed1d") },
                    { new Guid("ae660828-abbf-40ca-b6c6-40619059f731"), new Guid("6a555dc1-12a3-485e-89c3-a1966b96cefd") }
                });

            migrationBuilder.InsertData(
                table: "tblMovie",
                columns: new[] { "Id", "Cost", "Description", "DirectorId", "FormatId", "ImagePath", "Quantity", "RatingId", "Title" },
                values: new object[,]
                {
                    { new Guid("2b559b55-39a6-4b30-a948-ecfd944c5ddb"), 9.9900000000000002, "Pale Rider is a 1985 American Western film produced and directed by Clint Eastwood, who also stars in the lead role.", new Guid("ca0b1c64-4a73-43c7-99fd-58d587c42d4a"), new Guid("fb110472-8dad-44e7-ba69-48c87b45705f"), "PaleRider.jpg", 1, new Guid("60292baa-fe54-43b5-b943-bb12d859b088"), "Pale Rider" },
                    { new Guid("46e5479a-cb0e-4d1b-a388-dae89736fc30"), 6.9900000000000002, "Rocky is a 1976 American sports drama film directed by John G. Avildsen, written by and starring Sylvester Stallone.", new Guid("64f3a8c2-c4c4-4de1-984f-f1b833c42adb"), new Guid("82b46941-0e5d-46a3-8f40-a9e91536f458"), "Rocky.jpg", 2, new Guid("0df62934-4eaa-4f02-b644-5995ff9207c2"), "Rocky" },
                    { new Guid("857fafd7-548f-4673-9e02-061b78db2d09"), 12.5, "The Princess Bride is a 1987 American fantasy adventure comedy film directed and co-produced by Rob Reiner, starring Cary Elwes, Robin Wright, Mandy Patinkin, Chris Sarandon, Wallace Shawn, André the Giant, and Christopher Guest.", new Guid("9254a774-f57d-40c5-ac0e-ac75b1a39b28"), new Guid("8cb86598-7753-47f5-8d21-c8d826672e31"), "PrincessBride.jpg", 4, new Guid("236f43c1-6c28-4f4a-ae87-7c6ae52a63f1"), "The Princess Bride" },
                    { new Guid("99e7fc84-e21f-471c-b678-d633fa58c353"), 8.9900000000000002, "Jaws is a 1975 American thriller film directed by Steven Spielberg and based on the Peter Benchley 1974 novel of the same name.", new Guid("ca0b1c64-4a73-43c7-99fd-58d587c42d4a"), new Guid("fb110472-8dad-44e7-ba69-48c87b45705f"), "Jaws1.jpg", 1, new Guid("60292baa-fe54-43b5-b943-bb12d859b088"), "Jaws" },
                    { new Guid("ba384064-95c0-419e-ae5c-59535e3f815c"), 10.5, "Indiana Jones and the Last Crusade is a 1989 American action-adventure film directed by Steven Spielberg, from a story co-written by executive producer George Lucas.", new Guid("4f529afc-ca05-4ce0-abac-d0d6a50f2632"), new Guid("8cb86598-7753-47f5-8d21-c8d826672e31"), "IndianaJonesLastCrusade.jpg", 2, new Guid("00ea341c-1e83-48d2-beee-cd54faa7ef3d"), "Indiana Jones and the Last Crusade" },
                    { new Guid("c032744c-eee6-46c0-a9fe-a941f7682a78"), 7.5, "Star Wars: Episode IV – A New Hope is a 1977 American epic space-opera film written and directed by George Lucas, produced by Lucasfilm and distributed by 20th Century Fox.", new Guid("ca0b1c64-4a73-43c7-99fd-58d587c42d4a"), new Guid("fb110472-8dad-44e7-ba69-48c87b45705f"), "StarWarsNewHope.jpg", 1, new Guid("60292baa-fe54-43b5-b943-bb12d859b088"), "Star Wars: Episode IV – A New Hope" },
                    { new Guid("cf2cbf8f-4176-4aae-b857-e8ccb7db96fe"), 6.9900000000000002, "Other", new Guid("64f3a8c2-c4c4-4de1-984f-f1b833c42adb"), new Guid("82b46941-0e5d-46a3-8f40-a9e91536f458"), "Rocky.jpg", 2, new Guid("0df62934-4eaa-4f02-b644-5995ff9207c2"), "Other" }
                });

            migrationBuilder.InsertData(
                table: "tblOrder",
                columns: new[] { "Id", "CustomerId", "OrderDate", "ShipDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("2c2fa416-ed3e-4b4e-a284-d2c35241ddc9"), new Guid("5eefe923-6e61-459c-a985-5859a07cac42"), new DateTime(2022, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1e1e7a85-fa7a-46e1-8ce5-a6ffef1cd237") },
                    { new Guid("73cc1a47-e4e6-442f-a869-9d1d20828689"), new Guid("5eefe923-6e61-459c-a985-5859a07cac42"), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6a555dc1-12a3-485e-89c3-a1966b96cefd") },
                    { new Guid("832c223f-0c55-4075-aba1-2edb520e7c59"), new Guid("6c8c03c5-56ef-46e8-9d61-926db7bc6987"), new DateTime(2017, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6a555dc1-12a3-485e-89c3-a1966b96cefd") }
                });

            migrationBuilder.InsertData(
                table: "tblCartItem",
                columns: new[] { "Id", "CartId", "MovieId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("4b336dde-7b22-4348-924b-2fa2942e67fa"), new Guid("990e4962-0cab-437b-a56f-5320f9d78776"), new Guid("46e5479a-cb0e-4d1b-a388-dae89736fc30"), 1 },
                    { new Guid("6c5a62bb-ebd2-4326-86ac-2e523e1da2f7"), new Guid("990e4962-0cab-437b-a56f-5320f9d78776"), new Guid("99e7fc84-e21f-471c-b678-d633fa58c353"), 2 },
                    { new Guid("ee506f7b-f417-424f-9d52-34e3b4d2972a"), new Guid("ae660828-abbf-40ca-b6c6-40619059f731"), new Guid("99e7fc84-e21f-471c-b678-d633fa58c353"), 1 }
                });

            migrationBuilder.InsertData(
                table: "tblMovieGenre",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("0010d375-624f-45cd-98fd-1aece794011d"), new Guid("1122a214-a3ef-4781-8983-b8a5657e5305"), new Guid("857fafd7-548f-4673-9e02-061b78db2d09") },
                    { new Guid("08454763-8a8f-468f-aea1-8ddb09c68a1a"), new Guid("41e9c411-d9ed-4d10-ba8a-e2081e4fd0fd"), new Guid("46e5479a-cb0e-4d1b-a388-dae89736fc30") },
                    { new Guid("13e07b4c-34d5-4209-8846-c2a305b9925a"), new Guid("5b8fdf16-edb0-4940-970f-31b6bc3f99b0"), new Guid("46e5479a-cb0e-4d1b-a388-dae89736fc30") },
                    { new Guid("1f9d589d-8a9c-4f24-b9df-2d342d1df02b"), new Guid("e08fc682-701c-4749-9311-db3572bdd1a7"), new Guid("ba384064-95c0-419e-ae5c-59535e3f815c") },
                    { new Guid("2b5b31eb-f5ba-4c3a-ace3-af805b6d3914"), new Guid("5b8fdf16-edb0-4940-970f-31b6bc3f99b0"), new Guid("857fafd7-548f-4673-9e02-061b78db2d09") },
                    { new Guid("5ae93ca8-c4d1-47c3-badd-756990f1122e"), new Guid("41e9c411-d9ed-4d10-ba8a-e2081e4fd0fd"), new Guid("99e7fc84-e21f-471c-b678-d633fa58c353") },
                    { new Guid("8cfe160e-7a66-450c-963f-e6fd9350140f"), new Guid("005e4e0b-0c72-4bd3-8c72-94641fb6f2b0"), new Guid("2b559b55-39a6-4b30-a948-ecfd944c5ddb") },
                    { new Guid("933a399b-d7e1-42be-b9c2-b8a1c6b0ef94"), new Guid("e08fc682-701c-4749-9311-db3572bdd1a7"), new Guid("99e7fc84-e21f-471c-b678-d633fa58c353") },
                    { new Guid("c2154424-0e8b-4555-b973-df3eed3831d8"), new Guid("5b8fdf16-edb0-4940-970f-31b6bc3f99b0"), new Guid("ba384064-95c0-419e-ae5c-59535e3f815c") },
                    { new Guid("d5231164-a30d-45bf-8a4c-6032e5dda1eb"), new Guid("e08fc682-701c-4749-9311-db3572bdd1a7"), new Guid("c032744c-eee6-46c0-a9fe-a941f7682a78") },
                    { new Guid("e14cc6ee-8ab7-4603-a5d2-6326ad0a4f4f"), new Guid("e08fc682-701c-4749-9311-db3572bdd1a7"), new Guid("46e5479a-cb0e-4d1b-a388-dae89736fc30") },
                    { new Guid("e4af561f-6ed8-40d8-acaa-24aec3569408"), new Guid("0ee2675d-85a7-43dc-8156-9bdea6faaa81"), new Guid("c032744c-eee6-46c0-a9fe-a941f7682a78") },
                    { new Guid("ffbdb98b-de85-4cdd-a6df-b92272ee76b1"), new Guid("39306760-9db8-4571-99c5-9650aa4666f5"), new Guid("857fafd7-548f-4673-9e02-061b78db2d09") }
                });

            migrationBuilder.InsertData(
                table: "tblOrderItem",
                columns: new[] { "Id", "Cost", "MovieId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("03412211-70bb-49b2-a310-e250f4ba8fd6"), 9.9900000000000002, new Guid("99e7fc84-e21f-471c-b678-d633fa58c353"), new Guid("73cc1a47-e4e6-442f-a869-9d1d20828689"), 1 },
                    { new Guid("37a40bec-6ea0-4c99-9a50-d1b4981d1622"), 8.9900000000000002, new Guid("46e5479a-cb0e-4d1b-a388-dae89736fc30"), new Guid("73cc1a47-e4e6-442f-a869-9d1d20828689"), 1 },
                    { new Guid("9ffdc238-4cdc-42fa-8800-862317930065"), 10.99, new Guid("99e7fc84-e21f-471c-b678-d633fa58c353"), new Guid("2c2fa416-ed3e-4b4e-a284-d2c35241ddc9"), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCart_UserId",
                table: "tblCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCartItem_CartId",
                table: "tblCartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCartItem_MovieId",
                table: "tblCartItem",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovie_DirectorId",
                table: "tblMovie",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovie_FormatId",
                table: "tblMovie",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovie_RatingId",
                table: "tblMovie",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovieGenre_GenreId",
                table: "tblMovieGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovieGenre_MovieId",
                table: "tblMovieGenre",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_CustomerId",
                table: "tblOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderItem_MovieId",
                table: "tblOrderItem",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderItem_OrderId",
                table: "tblOrderItem",
                column: "OrderId");


            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[spGetMovies]
                    AS
                        select m.Id, m.RatingId, m.DirectorId, m.FormatId, m.Cost, m.Title, m.Description, m.Quantity,
                        r.Description RatingDescription,
                        f.Description FormatDescription,
                        d.FirstName, d.LastName
                        from tblMovie m
                        inner join tblRating r on m.RatingId = r.Id
                        inner join tblFormat f on m.FormatId = f.Id
                        inner join tblDirector d on m.DirectorId = d.Id
 
                    RETURN 0");

            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[spGetMoviesByGenre]
                     @GenreName VARCHAR(20)
                AS
                     select m.Id, m.RatingId, m.DirectorId, m.FormatId, m.Cost, m.Title, m.Description, m.Quantity,
                     r.Description RatingDescription,
                     f.Description FormatDescription,
                     d.FirstName, d.LastName
                     from tblMovie m
                     inner join tblRating r on m.RatingId = r.Id
                     inner join tblFormat f on m.FormatId = f.Id
                     inner join tblDirector d on m.DirectorId = d.Id
                     inner join tblMovieGenre mg on m.Id = mg.MovieId
                     inner join tblGenre g on mg.GenreId = g.Id
                     WHERE g.Description Like '%' + @GenreName + '%'
                RETURN 0
                ");

        }




        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCartItem");

            migrationBuilder.DropTable(
                name: "tblMovieGenre");

            migrationBuilder.DropTable(
                name: "tblOrderItem");

            migrationBuilder.DropTable(
                name: "tblCart");

            migrationBuilder.DropTable(
                name: "tblGenre");

            migrationBuilder.DropTable(
                name: "tblMovie");

            migrationBuilder.DropTable(
                name: "tblOrder");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblDirector");

            migrationBuilder.DropTable(
                name: "tblFormat");

            migrationBuilder.DropTable(
                name: "tblRating");

            migrationBuilder.DropTable(
                name: "tblCustomer");
        }
    }
}
