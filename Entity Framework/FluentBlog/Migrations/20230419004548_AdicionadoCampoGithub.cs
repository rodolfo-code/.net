using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluentBlog.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoCampoGithub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GitHub",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "SMALLDATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2023, 4, 19, 0, 45, 47, 949, DateTimeKind.Utc).AddTicks(8242),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2023, 4, 19, 0, 38, 33, 959, DateTimeKind.Utc).AddTicks(208));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GitHub",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "SMALLDATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2023, 4, 19, 0, 38, 33, 959, DateTimeKind.Utc).AddTicks(208),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2023, 4, 19, 0, 45, 47, 949, DateTimeKind.Utc).AddTicks(8242));
        }
    }
}
