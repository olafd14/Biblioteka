using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Biblioteka.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BookId", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "HasBorrowedBook", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5d67b19a-2097-44a5-b647-2947fc5adaf7", 0, null, "8383b5ac-6b5d-47aa-8407-33c2675deb08", "ApplicationUser", "admin@admin.com", true, false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEMrh96m7W/BtDy3ALaHPj0/gs/1Gpv+X/N1EJK7lc5pNfPGSUNVoz26xsqB50Kk4Dw==", null, false, "72d33deb-fdfd-4fe6-80e9-0f8b1b58e981", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ImageUrl", "NumberOfRatings", "Title", "UserRating", "isAvailable" },
                values: new object[,]
                {
                    { 8, "Cavan Scott", 1, "Ta książka skupia się na młodym hrabim Dooku, który jest jeszcze uczniem w Zakonie Jedi. Pokazuje jego wczesne lata wśród Jedi, jego relacje z nauczycielem, Yodą, oraz początki jego przemiany w mrocznego lorda Sithów.", "star-wars-dooku-stracony-dla-jedi-b-iext146760891.jpg", 0, "Dooku: Stracony dla Jedi", 0.0, true },
                    { 9, "Claudia Gray", 1, "Książka ta opowiada historię Qui-Gon Jinn'a i jego padawana, Obi-Wana Kenobiego, przed wydarzeniami filmu \"Star Wars: Episode I - The Phantom Menace\". Skupia się na ich relacji mistrz-uczeń oraz ich wspólnych przygodach i wyzwaniach.", "mistrz-i-uczen-star-wars-b-iext146752016.jpg", 0, "Mistrz i uczeń", 0.0, true },
                    { 10, "Mike Chen", 1, "Ta powieść śledzi losy dwóch braci, Maula i Savage'a Opressów, którzy zostali oddzieleni przez okrutne losy i zmuszeni do walki o przetrwanie na różnych ścieżkach życia. Ich historie są splątane z intrygami Sithów i walką o władzę w galaktyce.", "star-wars-bracia-b-iext149980208.jpg", 0, "Bracia", 0.0, true },
                    { 11, "Stephen King", 2, "Dzieci w małym miasteczku Derry w stanie Maine zaczynają znikać, a grupa przyjaciół staje w obliczu tajemniczej i przerażającej istoty, która przybiera różne formy, a która kryje się pod nazwą \"To\".", "it-b-iext137327068.jpg", 0, "It", 0.0, true }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Literatura science fiction wyróżnia się tym, że eksploruje fantastyczne światy, technologie i społeczeństwa, często w kontekście naukowych hipotez lub możliwych przyszłych scenariuszy. Ta kategoria literacka często skupia się na tematach związanych z przyszłością, podróżami kosmicznymi, sztuczną inteligencją, alternatywnymi rzeczywistościami i wpływem postępu technologicznego na ludzkość.");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Literatura fantastyczna to jeden z gatunków literackich, w przypadku którego fabuła zawiera, na przykład, elementy związane bezpośrednio z magią. Dla literatury fantasy charakterystyczne jest tworzenie miejsca zdarzeń nieistniejącego w rzeczywistym świecie.", "Fantasy" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "Literatura horroru wyróżnia się tym, że stara się wywołać uczucie strachu, niepokoju i grozy u czytelnika. Często wykorzystuje napięcie, atmosferę oraz elementy nadprzyrodzone lub makabryczne, aby budować suspens i prowadzić do nieoczekiwanych zwrotów akcji. Horror eksploruje ludzkie lęki, tabu i obsesje, często konfrontując czytelnika z najgłębszymi mrocznymi stronami ludzkiej natury.", "Horror" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ImageUrl", "NumberOfRatings", "Title", "UserRating", "isAvailable" },
                values: new object[,]
                {
                    { 4, "Andrzej Sapkowski", 3, "Główny wątek koncentruje się na poszukiwaniach Ciri oraz wydarzeniach politycznych w królestwach Północy, gdzie Geralt staje w obliczu nowych wrogów i wyzwań.", "czas-pogardy-wiedzmin-tom-4-b-iext146808438.jpg", 0, "Czas pogardy", 0.0, true },
                    { 5, "Andrzej Sapkowski", 3, "Geralt i jego towarzysze wyruszają w kolejną niebezpieczną podróż, tym razem z zamiarem obrony Ciri przed jej przeznaczeniem, a także stawiając czoła coraz bardziej złożonym zagrożeniom.", "chrzest-ognia-wiedzmin-tom-5-b-iext146808430.jpg", 0, "Chrzest ognia", 0.0, true },
                    { 6, "Andrzej Sapkowski", 3, "Główna akcja koncentruje się na rozstrzygnięciu losów Ciri, która znajduje się w centrum konfliktu między różnymi frakcjami, a także na decydującym starciu między siłami dobra i zła.", "wieza-jaskolki-wiedzmin-tom-6-b-iext146806990.jpg", 0, "Wieża Jaskółki", 0.0, true },
                    { 7, "Andrzej Sapkowski", 3, "Finalna część sagi, w której wszystkie wątki i losy głównych bohaterów splatają się w epicki sposób, prowadząc do ostatecznego starcia między światłem a ciemnością.", "pani-jeziora-wiedzmin-tom-7-b-iext146807615.jpg", 0, "Pani Jeziora", 0.0, true },
                    { 12, "Andrzej Sapkowski", 3, "Zbiór opowiadań, które wprowadzają czytelnika w świat wiedźmina Geralta z Rivii, przedstawiając jego przygody z różnymi potworami i ludźmi, a także ukazując złożoność świata, w którym żyje.", "ostatnie-zyczenie-wiedzmin-tom-1-b-iext146796925.jpg", 0, "Ostatnie życzenie", 0.0, true },
                    { 13, "Andrzej Sapkowski", 3, "Kontynuacja przygód Geralta, który walczy z kolejnymi bestiami i stawia czoła moralnym dylematom, jednocześnie odkrywając coraz więcej tajemnic swojej przeszłości.", "miecz-przeznaczenia-wiedzmin-tom-2-b-iext146798643.jpg", 0, "Miecz przeznaczenia", 0.0, true },
                    { 14, "Andrzej Sapkowski", 3, " Pierwsza powieść z serii, gdzie historia rozwija się w głębszy sposób, przedstawiając polityczne intrygi, konflikty międzyrasowe oraz losy Ciri, dziedziczki z rodu królewskiego.", "krew-elfow-wiedzmin-tom-3-b-iext146807006.jpg", 0, "Krew elfów", 0.0, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d67b19a-2097-44a5-b647-2947fc5adaf7");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ImageUrl", "NumberOfRatings", "Title", "UserRating", "isAvailable" },
                values: new object[,]
                {
                    { 1, "Sapkowski", 1, "Wiedźmin", null, 0, "Witcher", 0.0, true },
                    { 2, "Sapkowski", 2, "Wiedźmin 2", null, 0, "Witcher 2", 0.0, true }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Space jurney");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Scary movie", "Horror" });
        }
    }
}
