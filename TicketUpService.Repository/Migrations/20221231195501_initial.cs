using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketUpService.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    email = table.Column<string>(type: "nvarchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(500)", nullable: false),
                    email = table.Column<string>(type: "varchar(500)", nullable: false),
                    WhatsApp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    store_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.id);
                    table.ForeignKey(
                        name: "FK_Client_Store_store_id",
                        column: x => x.store_id,
                        principalTable: "Store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    login = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    user_profile_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    store_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Store_store_id",
                        column: x => x.store_id,
                        principalTable: "Store",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserProfile_user_profile_id",
                        column: x => x.user_profile_id,
                        principalTable: "UserProfile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    score_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rescue = table.Column<bool>(type: "bit", nullable: false),
                    rescued_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    client_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_create_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.id);
                    table.ForeignKey(
                        name: "FK_Score_Client_client_id",
                        column: x => x.client_id,
                        principalTable: "Client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Score_User_user_create_id",
                        column: x => x.user_create_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_store_id",
                table: "Client",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_Score_client_id",
                table: "Score",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Score_user_create_id",
                table: "Score",
                column: "user_create_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_store_id",
                table: "User",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_user_profile_id",
                table: "User",
                column: "user_profile_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "UserProfile");
        }
    }
}
