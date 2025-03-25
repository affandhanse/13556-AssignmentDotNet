using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAppointmentSystem.Migrations
{
    public partial class newUpdateInitial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a76f06ef-4878-49cb-b8e2-6489cb3454ba", "20482ccb-990d-42a6-b979-2f4605d28b9f", "Patient", "PATIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a76f06ef-4878-49cb-c9e2-6489cb3454ba", "38451c05-9217-4950-8d23-320ae4843c3a", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a76f06ef-4878-49cb-o7e2-6489cb3454ba", "5be201f8-aaa6-47c6-8ccc-64f723f8daaf", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a76f06ef-4878-49cb-o7e2-6489cb3454ba", "a4e636da-e2f5-49eb-850f-b470e22812a9" });
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
                keyValues: new object[] { "a76f06ef-4878-49cb-o7e2-6489cb3454ba", "a4e636da-e2f5-49eb-850f-b470e22812a9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a76f06ef-4878-49cb-o7e2-6489cb3454ba");
        }
    }
}
