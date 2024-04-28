using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteka.Migrations
{
    /// <inheritdoc />
    public partial class AddFotoToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d67b19a-2097-44a5-b647-2947fc5adaf7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d925859e-4d97-484b-a429-a344f37ed341", "AQAAAAIAAYagAAAAEBj5GYMqlMnUS6oc59uXrtPBivHXm7vlxcxVnCoJKDhj+C6lB2UE9ZaeowzOCXEdXw==", "72d3af0f-73f4-4619-b17d-727effd212a2" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "\\images\\czas-pogardy-wiedzmin-tom-4-b-iext146808438.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "\\images\\chrzest-ognia-wiedzmin-tom-5-b-iext146808430.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "\\images\\wieza-jaskolki-wiedzmin-tom-6-b-iext146806990.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "\\images\\pani-jeziora-wiedzmin-tom-7-b-iext146807615.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "\\images\\star-wars-dooku-stracony-dla-jedi-b-iext146760891.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "\\images\\mistrz-i-uczen-star-wars-b-iext146752016.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "\\images\\star-wars-bracia-b-iext149980208.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "\\images\\it-b-iext137327068.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "\\images\\ostatnie-zyczenie-wiedzmin-tom-1-b-iext146796925.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "\\images\\miecz-przeznaczenia-wiedzmin-tom-2-b-iext146798643.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "\\images\\krew-elfow-wiedzmin-tom-3-b-iext146807006.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d67b19a-2097-44a5-b647-2947fc5adaf7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8383b5ac-6b5d-47aa-8407-33c2675deb08", "AQAAAAIAAYagAAAAEMrh96m7W/BtDy3ALaHPj0/gs/1Gpv+X/N1EJK7lc5pNfPGSUNVoz26xsqB50Kk4Dw==", "72d33deb-fdfd-4fe6-80e9-0f8b1b58e981" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "czas-pogardy-wiedzmin-tom-4-b-iext146808438.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "chrzest-ognia-wiedzmin-tom-5-b-iext146808430.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "wieza-jaskolki-wiedzmin-tom-6-b-iext146806990.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "pani-jeziora-wiedzmin-tom-7-b-iext146807615.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "star-wars-dooku-stracony-dla-jedi-b-iext146760891.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "mistrz-i-uczen-star-wars-b-iext146752016.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "star-wars-bracia-b-iext149980208.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "it-b-iext137327068.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "ostatnie-zyczenie-wiedzmin-tom-1-b-iext146796925.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "miecz-przeznaczenia-wiedzmin-tom-2-b-iext146798643.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "krew-elfow-wiedzmin-tom-3-b-iext146807006.jpg");
        }
    }
}
