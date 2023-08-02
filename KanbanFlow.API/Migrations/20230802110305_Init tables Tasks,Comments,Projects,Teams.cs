using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KanbanFlow.API.Migrations
{
    /// <inheritdoc />
    public partial class InittablesTasksCommentsProjectsTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectManagerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReporterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfReport = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_ReporterId",
                        column: x => x.ReporterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_CommentatorId",
                        column: x => x.CommentatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Comments_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_AspNetUsers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ProjectManagerId", "ProjectName" },
                values: new object[,]
                {
                    { new Guid("59601d29-d1ca-4278-aa7f-61b9dd88f9cd"), "977890c6-ed82-44d2-89d1-e9bcbe044342", "Cybersphere" },
                    { new Guid("77876cb3-c59b-4259-84d6-ef97d0ef54c8"), "977890c6-ed82-44d2-89d1-e9bcbe044342", "AuroraX" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "DateOfReport", "Description", "OwnerId", "Priority", "ProjectId", "ReporterId", "Status", "TeamId", "Title" },
                values: new object[,]
                {
                    { new Guid("0f446d5b-d6b6-4830-bdd4-dd00ee577f4c"), new DateTime(2023, 8, 2, 13, 3, 5, 106, DateTimeKind.Local).AddTicks(7013), "We need to have options for login and register for users.", null, 3, new Guid("59601d29-d1ca-4278-aa7f-61b9dd88f9cd"), "977890c6-ed82-44d2-89d1-e9bcbe044342", 0, new Guid("987bc5f6-2999-4943-9e95-b2e4b74ed567"), "Create Auth Controller." },
                    { new Guid("30627367-6325-4503-b55e-c4584fc72cb6"), new DateTime(2023, 8, 2, 13, 3, 5, 106, DateTimeKind.Local).AddTicks(7008), "Create first concept of UI that will be presented on a meeting.", null, 2, new Guid("77876cb3-c59b-4259-84d6-ef97d0ef54c8"), "977890c6-ed82-44d2-89d1-e9bcbe044342", 0, new Guid("f4cf9c55-63b8-4a7f-9072-a9c3930b05ef"), "Create mocks of UI" },
                    { new Guid("7559cedd-4c01-4cb7-89de-be64afa35df4"), new DateTime(2023, 8, 2, 13, 3, 5, 106, DateTimeKind.Local).AddTicks(7018), "There is a bug when dispalying sum up statisitcs of a space ship. Sometimes the statistics won't load.", "896cbb0f-ce93-43ec-8915-eb077fd3833d", 3, new Guid("59601d29-d1ca-4278-aa7f-61b9dd88f9cd"), "7a5b4d2b-a396-44e0-b918-4befcb2f9a4e", 2, new Guid("d354e006-50ca-471d-b768-42e37cb1d750"), "Fix bug with displaying sum up statistics." },
                    { new Guid("79705c41-29cb-4098-bb62-9bb3b099acb6"), new DateTime(2023, 8, 2, 13, 3, 5, 106, DateTimeKind.Local).AddTicks(6957), "Create DbContext class to init the database.", "977890c6-ed82-44d2-89d1-e9bcbe044342", 2, new Guid("77876cb3-c59b-4259-84d6-ef97d0ef54c8"), "977890c6-ed82-44d2-89d1-e9bcbe044342", 1, new Guid("25ef9129-9a40-4016-a1ac-e16c1bd6c307"), "Init DB" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "TeamName" },
                values: new object[,]
                {
                    { new Guid("25ef9129-9a40-4016-a1ac-e16c1bd6c307"), "Code Wizards" },
                    { new Guid("987bc5f6-2999-4943-9e95-b2e4b74ed567"), "Tech Titans" },
                    { new Guid("d354e006-50ca-471d-b768-42e37cb1d750"), "Bug Busters" },
                    { new Guid("f4cf9c55-63b8-4a7f-9072-a9c3930b05ef"), "Pixel Pioneers" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentatorId", "Date", "Description", "TaskId" },
                values: new object[,]
                {
                    { new Guid("17b7acc2-42b3-41ba-956c-7d7291f4a898"), "6c3357e6-f24e-487e-926a-d6cf266790c1", new DateTime(2023, 8, 2, 13, 3, 5, 106, DateTimeKind.Local).AddTicks(7055), "We need to add new table to store logs!", new Guid("79705c41-29cb-4098-bb62-9bb3b099acb6") },
                    { new Guid("8cc258cf-919f-45af-9cf4-b64069b4ead2"), "7a5b4d2b-a396-44e0-b918-4befcb2f9a4e", new DateTime(2023, 8, 2, 13, 3, 5, 106, DateTimeKind.Local).AddTicks(7061), "I need help here from team @Tech Titans", new Guid("7559cedd-4c01-4cb7-89de-be64afa35df4") }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "MemberId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("758091fd-6ec8-4b9b-b78a-9471f42c484f"), "896cbb0f-ce93-43ec-8915-eb077fd3833d", new Guid("987bc5f6-2999-4943-9e95-b2e4b74ed567") },
                    { new Guid("81d15f82-3e9c-47c3-b299-b1581cd65c2c"), "ac77693f-523c-407f-ac9b-5730b9f2af62", new Guid("f4cf9c55-63b8-4a7f-9072-a9c3930b05ef") },
                    { new Guid("9006d8b3-783c-40b5-acda-1ee97d12828d"), "785e3ed9-9388-4ca9-922b-ab69cbd9651c", new Guid("987bc5f6-2999-4943-9e95-b2e4b74ed567") },
                    { new Guid("a163dbb9-8c52-4d9e-9146-c551d73ed683"), "c75d74ac-587c-4793-89a2-c1aff590fef0", new Guid("25ef9129-9a40-4016-a1ac-e16c1bd6c307") },
                    { new Guid("a816cee5-8c76-41eb-8d98-97b973d7d4ae"), "4f2e8b12-fb8b-4f0d-891a-34afad4095f8", new Guid("25ef9129-9a40-4016-a1ac-e16c1bd6c307") },
                    { new Guid("c9dea465-9682-471e-9417-a94802c901d5"), "6c3357e6-f24e-487e-926a-d6cf266790c1", new Guid("25ef9129-9a40-4016-a1ac-e16c1bd6c307") },
                    { new Guid("da33d048-0f80-4699-a3d4-d96af6da8ddf"), "c1e5da6e-e4e4-4a94-a79e-e65ef7bd6746", new Guid("f4cf9c55-63b8-4a7f-9072-a9c3930b05ef") },
                    { new Guid("e896018d-168d-4c76-a2b2-59e8df944970"), "7a5b4d2b-a396-44e0-b918-4befcb2f9a4e", new Guid("d354e006-50ca-471d-b768-42e37cb1d750") },
                    { new Guid("ea95ac6c-83ca-4221-85d1-f60011e8c103"), "ea708fc7-69bb-4f37-bef8-5bb2e6731aa1", new Guid("d354e006-50ca-471d-b768-42e37cb1d750") },
                    { new Guid("fd84ee40-5579-4433-97ae-a13498ea473f"), "6d018538-71da-4dbe-95a3-c334150375aa", new Guid("987bc5f6-2999-4943-9e95-b2e4b74ed567") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentatorId",
                table: "Comments",
                column: "CommentatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TaskId",
                table: "Comments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ReporterId",
                table: "Tasks",
                column: "ReporterId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_MemberId",
                table: "TeamMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
