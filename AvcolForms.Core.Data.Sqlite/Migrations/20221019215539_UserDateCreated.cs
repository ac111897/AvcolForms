﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvcolForms.Core.Data.Sqlite.Migrations;

public partial class UserDateCreated : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<DateTimeOffset>(
            name: "Created",
            table: "AspNetUsers",
            type: "TEXT",
            nullable: false,
            defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Created",
            table: "AspNetUsers");
    }
}
