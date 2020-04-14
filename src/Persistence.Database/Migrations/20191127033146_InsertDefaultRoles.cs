using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Database.Migrations
{
    public partial class InsertDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "994f377d-a3c8-4189-ad3d-53a8dd865f15", "d466f1b9-7d61-4f55-92de-be2f27bde072", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ca7e437-f3e8-4069-a833-0db87e0c8929", "b28967ad-4064-4971-98e7-3c33696a1215", "Seller", "Seller" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "994f377d-a3c8-4189-ad3d-53a8dd865f15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ca7e437-f3e8-4069-a833-0db87e0c8929");
        }
    }
}
