using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    public partial class newInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterSocialMedia",
                table: "MasterSocialMedia");

            migrationBuilder.RenameTable(
                name: "MasterSocialMedia",
                newName: "MasterSocialMedium");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TransactionNewsletters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "TransactionNewsletters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "TransactionNewsletters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "TransactionNewsletters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TransactionNewsletters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TransactionNewsletters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TransactionContactUs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "TransactionContactUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "TransactionContactUs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "TransactionContactUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TransactionContactUs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TransactionContactUs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TransactionBookTables",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "TransactionBookTables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "TransactionBookTables",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "TransactionBookTables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TransactionBookTables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TransactionBookTables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterSocialMedium",
                table: "MasterSocialMedium",
                column: "MasterSocialMediumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterSocialMedium",
                table: "MasterSocialMedium");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TransactionBookTables");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "TransactionBookTables");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "TransactionBookTables");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "TransactionBookTables");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TransactionBookTables");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TransactionBookTables");

            migrationBuilder.RenameTable(
                name: "MasterSocialMedium",
                newName: "MasterSocialMedia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterSocialMedia",
                table: "MasterSocialMedia",
                column: "MasterSocialMediumId");
        }
    }
}
