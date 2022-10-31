﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvcolForms.Core.Data.Migrations.SqlServer.Migrations
{
    public partial class FormUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastLogin",
                table: "AspNetUsers",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Closes = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(72)", maxLength: 72, nullable: false),
                    Recipients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Receiver = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Modified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormContent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentType = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Modified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormContent_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormResponse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Modified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormResponse_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormResponse_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContentResponses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespondsToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FormResponseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Modified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentResponses_FormContent_RespondsToId",
                        column: x => x.RespondsToId,
                        principalTable: "FormContent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContentResponses_FormResponse_FormResponseId",
                        column: x => x.FormResponseId,
                        principalTable: "FormResponse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentResponses_FormResponseId",
                table: "ContentResponses",
                column: "FormResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentResponses_RespondsToId",
                table: "ContentResponses",
                column: "RespondsToId");

            migrationBuilder.CreateIndex(
                name: "IX_FormContent_FormId",
                table: "FormContent",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormResponse_FormId",
                table: "FormResponse",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormResponse_UserId",
                table: "FormResponse",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentResponses");

            migrationBuilder.DropTable(
                name: "FormContent");

            migrationBuilder.DropTable(
                name: "FormResponse");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropColumn(
                name: "LastLogin",
                table: "AspNetUsers");
        }
    }
}
