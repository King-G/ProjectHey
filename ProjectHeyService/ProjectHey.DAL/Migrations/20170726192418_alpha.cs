using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectHey.DAL.Migrations
{
    public partial class alpha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(maxLength: 500, nullable: false),
                    ReportType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SignalRRoom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(nullable: true),
                    Roomname = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignalRRoom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityID = table.Column<string>(nullable: true),
                    CityName = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(maxLength: 320, nullable: true),
                    FacebookId = table.Column<string>(nullable: false),
                    FacebookToken = table.Column<string>(nullable: false),
                    Firstname = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    IsBanned = table.Column<bool>(nullable: false),
                    IsHidden = table.Column<bool>(nullable: false),
                    Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    ProfilePictureURL = table.Column<string>(maxLength: 2000, nullable: true),
                    Username = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    SignalRRoomId = table.Column<int>(nullable: false),
                    TotalSignalRUsers = table.Column<int>(nullable: false),
                    TotalUsers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_SignalRRoom_SignalRRoomId",
                        column: x => x.SignalRRoomId,
                        principalTable: "SignalRRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Advertisement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdvertisementType = table.Column<int>(nullable: false),
                    AdvertisementURL = table.Column<string>(maxLength: 2000, nullable: true),
                    AmountRemaining = table.Column<int>(nullable: false),
                    PictureURL = table.Column<string>(maxLength: 2000, nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisement_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Language = table.Column<int>(nullable: false),
                    MaximumConnections = table.Column<int>(nullable: false),
                    Radius = table.Column<int>(nullable: false),
                    Sound = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSetting_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Connection",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    UserConnectionId = table.Column<int>(nullable: false),
                    GivenUsername = table.Column<string>(nullable: true),
                    IsBlocked = table.Column<bool>(nullable: false),
                    IsHidden = table.Column<bool>(nullable: false),
                    Progress = table.Column<double>(nullable: false),
                    SignalRRoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connection", x => new { x.UserId, x.UserConnectionId });
                    table.ForeignKey(
                        name: "FK_Connection_SignalRRoom_SignalRRoomId",
                        column: x => x.SignalRRoomId,
                        principalTable: "SignalRRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Connection_User_UserConnectionId",
                        column: x => x.UserConnectionId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Connection_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeedbackType = table.Column<int>(nullable: false),
                    Message = table.Column<string>(maxLength: 500, nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reported",
                columns: table => new
                {
                    ReporterUserId = table.Column<int>(nullable: false),
                    ReportedUserId = table.Column<int>(nullable: false),
                    ReportId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reported", x => new { x.ReporterUserId, x.ReportedUserId });
                    table.ForeignKey(
                        name: "FK_Reported_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reported_User_ReportedUserId",
                        column: x => x.ReportedUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reported_User_ReporterUserId",
                        column: x => x.ReporterUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SignalRUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsConnected = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignalRUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignalRUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCategory",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategory", x => new { x.UserId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_UserCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCategory_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvertisementCategory",
                columns: table => new
                {
                    AdvertisementId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementCategory", x => new { x.AdvertisementId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_AdvertisementCategory_Advertisement_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertisementCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAdvertisement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    AdvertisementId = table.Column<int>(nullable: false),
                    IsClicked = table.Column<bool>(nullable: false),
                    ReportId = table.Column<int>(nullable: true),
                    ViewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdvertisement", x => new { x.Id, x.UserId, x.AdvertisementId });
                    table.ForeignKey(
                        name: "FK_UserAdvertisement_Advertisement_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAdvertisement_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAdvertisement_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SignalRMessage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(maxLength: 500, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SignalRRoomId = table.Column<int>(nullable: false),
                    SignalRUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignalRMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignalRMessage_SignalRRoom_SignalRRoomId",
                        column: x => x.SignalRRoomId,
                        principalTable: "SignalRRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SignalRMessage_SignalRUser_SignalRUserId",
                        column: x => x.SignalRUserId,
                        principalTable: "SignalRUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignalRUserRoom",
                columns: table => new
                {
                    SignalRUserId = table.Column<int>(nullable: false),
                    SignalRRoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignalRUserRoom", x => new { x.SignalRUserId, x.SignalRRoomId });
                    table.ForeignKey(
                        name: "FK_SignalRUserRoom_SignalRRoom_SignalRRoomId",
                        column: x => x.SignalRRoomId,
                        principalTable: "SignalRRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SignalRUserRoom_SignalRUser_SignalRUserId",
                        column: x => x.SignalRUserId,
                        principalTable: "SignalRUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_UserId",
                table: "Advertisement",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementCategory_AdvertisementId",
                table: "AdvertisementCategory",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementCategory_CategoryId",
                table: "AdvertisementCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSetting_UserId",
                table: "AppSetting",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_Name",
                table: "Category",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_SignalRRoomId",
                table: "Category",
                column: "SignalRRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_SignalRRoomId",
                table: "Connection",
                column: "SignalRRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_UserConnectionId",
                table: "Connection",
                column: "UserConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_UserId",
                table: "Connection",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_UserId",
                table: "Feedback",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reported_ReportId",
                table: "Reported",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Reported_ReportedUserId",
                table: "Reported",
                column: "ReportedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reported_ReporterUserId",
                table: "Reported",
                column: "ReporterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SignalRMessage_SignalRRoomId",
                table: "SignalRMessage",
                column: "SignalRRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_SignalRMessage_SignalRUserId",
                table: "SignalRMessage",
                column: "SignalRUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SignalRUser_UserId",
                table: "SignalRUser",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SignalRUserRoom_SignalRRoomId",
                table: "SignalRUserRoom",
                column: "SignalRRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_SignalRUserRoom_SignalRUserId",
                table: "SignalRUserRoom",
                column: "SignalRUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_FacebookId",
                table: "User",
                column: "FacebookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAdvertisement_AdvertisementId",
                table: "UserAdvertisement",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdvertisement_ReportId",
                table: "UserAdvertisement",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdvertisement_UserId",
                table: "UserAdvertisement",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategory_CategoryId",
                table: "UserCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategory_UserId",
                table: "UserCategory",
                column: "UserId");

            migrationBuilder.Sql(@"ALTER TABLE [dbo].[User] ADD [Location] geography NULL");
            migrationBuilder.Sql(@"ALTER TABLE [dbo].[Advertisement] ADD [Location] geography NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisementCategory");

            migrationBuilder.DropTable(
                name: "AppSetting");

            migrationBuilder.DropTable(
                name: "Connection");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Reported");

            migrationBuilder.DropTable(
                name: "SignalRMessage");

            migrationBuilder.DropTable(
                name: "SignalRUserRoom");

            migrationBuilder.DropTable(
                name: "UserAdvertisement");

            migrationBuilder.DropTable(
                name: "UserCategory");

            migrationBuilder.DropTable(
                name: "SignalRUser");

            migrationBuilder.DropTable(
                name: "Advertisement");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "SignalRRoom");
        }
    }
}
