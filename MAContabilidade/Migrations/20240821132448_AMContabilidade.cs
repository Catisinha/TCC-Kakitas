using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAContabilidade.Migrations
{
    /// <inheritdoc />
    public partial class AMContabilidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df77fe21-4666-440d-8e57-76ecc6b06cdd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fee388a-5a3a-47a0-8722-040ff11d7e79");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29f9bd57-7ece-4331-8d2f-7e0dba34039e", null, "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3bfe4dd8-deaf-4c36-8c4e-2695e370d9f8", 0, "bacb6b7b-86c6-4718-bf6f-221a2278a926", "contatoampmcontabilidade@gmail.com", true, false, null, "CONTATOAMPMCONTABILIDADE@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAENsVS1PZRDrYZhy26BeCe7UUyVHYvfXlcnjTdjN1Fl6Jd5FHGLrTZe6wqw/FT8Bntw==", null, false, "4a67ab27-afd2-4a64-ae98-44fc1cb5d7b8", false, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29f9bd57-7ece-4331-8d2f-7e0dba34039e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3bfe4dd8-deaf-4c36-8c4e-2695e370d9f8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df77fe21-4666-440d-8e57-76ecc6b06cdd", null, "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5fee388a-5a3a-47a0-8722-040ff11d7e79", 0, "85bdab2a-ff39-4be7-a8d2-1d4092853d05", "contatoampmcontabilidade@gmail.com", true, false, null, "CONTATOAMPMCONTABILIDADE@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAENWo0YY5oYUB+apuWNmLsrJ2u18AATjkD9XevVN8P4fN+blepCKN4kLJx+5py2pbBA==", null, false, "364762f5-1c41-4c5f-adc0-cf352f0d537f", false, "Admin" });
        }
    }
}
