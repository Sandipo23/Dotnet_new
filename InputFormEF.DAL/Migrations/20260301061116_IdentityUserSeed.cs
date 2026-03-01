using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InputFormEF.DAL.Migrations
{
    /// <inheritdoc />
    public partial class IdentityUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "fcd534fa-eaac-415e-b48d-81499e8af369", "sandipbhandari@gmail.com", true, false, null, "SANDIPBHANDARI6699@GMAIL.COM", "SANDIP", "AQAAAAIAAYagAAAAEINk4Dtr4TtlQnI6BwpMPp7OiovNVy1P5M19NNVLF77UgPvqyam+AvFax/2cqDpK5Q==", null, false, "0b466d41-3ed7-4a7d-932a-bd712035db9f", false, "sandip" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
