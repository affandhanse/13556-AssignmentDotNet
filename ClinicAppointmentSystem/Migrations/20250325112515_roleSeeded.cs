using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAppointmentSystem.Migrations
{
    public partial class roleSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a76f06ef-4878-49cb-b8e2-6489cb3454ba", "844f6d56-24fb-4c50-8789-f3f94c3dad30", "Patient", "PATIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a76f06ef-4878-49cb-c9e2-6489cb3454ba", "84e3cbea-595a-4ec1-ad73-ed34120ae3a5", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a76f06ef-4878-49cb-o7e2-6489cb3454ba", "249f97f0-154a-4274-ad73-c769a72846a8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a76f06ef-4878-49cb-o7e2-6489cb3454ba", "8b23f9ca-a0b8-4da2-b83a-83a235043957" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a76f06ef-4878-49cb-b8e2-6489cb3454ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a76f06ef-4878-49cb-c9e2-6489cb3454ba");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a76f06ef-4878-49cb-o7e2-6489cb3454ba", "8b23f9ca-a0b8-4da2-b83a-83a235043957" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a76f06ef-4878-49cb-o7e2-6489cb3454ba");
        }
    }
}
