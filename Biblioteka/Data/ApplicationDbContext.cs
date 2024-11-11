using Biblioteka.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<BorrowHistory> BorrowHistorys { get; set; }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Sci-fi", Description = "Literatura science fiction wyróżnia się tym, że eksploruje fantastyczne światy, technologie i społeczeństwa, często w kontekście naukowych hipotez lub możliwych przyszłych scenariuszy. Ta kategoria literacka często skupia się na tematach związanych z przyszłością, podróżami kosmicznymi, sztuczną inteligencją, alternatywnymi rzeczywistościami i wpływem postępu technologicznego na ludzkość." },
                new Category { Id = 2, Name = "Fantasy", Description = "Literatura fantastyczna to jeden z gatunków literackich, w przypadku którego fabuła zawiera, na przykład, elementy związane bezpośrednio z magią. Dla literatury fantasy charakterystyczne jest tworzenie miejsca zdarzeń nieistniejącego w rzeczywistym świecie." },
                new Category { Id = 3, Name = "Horror", Description = "Literatura horroru wyróżnia się tym, że stara się wywołać uczucie strachu, niepokoju i grozy u czytelnika. Często wykorzystuje napięcie, atmosferę oraz elementy nadprzyrodzone lub makabryczne, aby budować suspens i prowadzić do nieoczekiwanych zwrotów akcji. Horror eksploruje ludzkie lęki, tabu i obsesje, często konfrontując czytelnika z najgłębszymi mrocznymi stronami ludzkiej natury." });

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 12, ImageUrl = "\\images\\ostatnie-zyczenie-wiedzmin-tom-1-b-iext146796925.jpg", Title = "Ostatnie życzenie", Description = "Zbiór opowiadań, które wprowadzają czytelnika w świat wiedźmina Geralta z Rivii, przedstawiając jego przygody z różnymi potworami i ludźmi, a także ukazując złożoność świata, w którym żyje.", Author = "Andrzej Sapkowski", isAvailable = true, CategoryId = 2, CopiesNumber = 3, CopiesAvailable = 3 },
                new Book { Id = 13, ImageUrl = "\\images\\miecz-przeznaczenia-wiedzmin-tom-2-b-iext146798643.jpg", Title = "Miecz przeznaczenia", Description = "Kontynuacja przygód Geralta, który walczy z kolejnymi bestiami i stawia czoła moralnym dylematom, jednocześnie odkrywając coraz więcej tajemnic swojej przeszłości.", Author = "Andrzej Sapkowski", isAvailable = true, CategoryId = 2, CopiesNumber = 4, CopiesAvailable = 4 },
                new Book {Id = 14, ImageUrl = "\\images\\krew-elfow-wiedzmin-tom-3-b-iext146807006.jpg", Title = "Krew elfów", Description = " Pierwsza powieść z serii, gdzie historia rozwija się w głębszy sposób, przedstawiając polityczne intrygi, konflikty międzyrasowe oraz losy Ciri, dziedziczki z rodu królewskiego.", Author = "Andrzej Sapkowski", isAvailable = true, CategoryId = 2, CopiesNumber = 3, CopiesAvailable = 3 },
                new Book {Id = 4, ImageUrl = "\\images\\czas-pogardy-wiedzmin-tom-4-b-iext146808438.jpg", Title = "Czas pogardy", Description = "Główny wątek koncentruje się na poszukiwaniach Ciri oraz wydarzeniach politycznych w królestwach Północy, gdzie Geralt staje w obliczu nowych wrogów i wyzwań.", Author = "Andrzej Sapkowski", isAvailable = true, CategoryId = 2, CopiesNumber = 6, CopiesAvailable = 6 },
                new Book {Id = 5, ImageUrl = "\\images\\chrzest-ognia-wiedzmin-tom-5-b-iext146808430.jpg", Title = "Chrzest ognia", Description = "Geralt i jego towarzysze wyruszają w kolejną niebezpieczną podróż, tym razem z zamiarem obrony Ciri przed jej przeznaczeniem, a także stawiając czoła coraz bardziej złożonym zagrożeniom.", Author = "Andrzej Sapkowski", isAvailable = true, CategoryId = 2, CopiesNumber = 5, CopiesAvailable = 5 },
                new Book {Id = 6, ImageUrl = "\\images\\wieza-jaskolki-wiedzmin-tom-6-b-iext146806990.jpg", Title = "Wieża Jaskółki", Description = "Główna akcja koncentruje się na rozstrzygnięciu losów Ciri, która znajduje się w centrum konfliktu między różnymi frakcjami, a także na decydującym starciu między siłami dobra i zła.", Author = "Andrzej Sapkowski", isAvailable = true, CategoryId = 2, CopiesNumber = 3, CopiesAvailable = 3 },
                new Book {Id = 7, ImageUrl = "\\images\\pani-jeziora-wiedzmin-tom-7-b-iext146807615.jpg", Title = "Pani Jeziora", Description = "Finalna część sagi, w której wszystkie wątki i losy głównych bohaterów splatają się w epicki sposób, prowadząc do ostatecznego starcia między światłem a ciemnością.", Author = "Andrzej Sapkowski", isAvailable = true, CategoryId = 2, CopiesNumber = 3, CopiesAvailable = 3 },
                new Book { Id = 8, ImageUrl = "\\images\\star-wars-dooku-stracony-dla-jedi-b-iext146760891.jpg", Title = "Dooku: Stracony dla Jedi", Description = "Ta książka skupia się na młodym hrabim Dooku, który jest jeszcze uczniem w Zakonie Jedi. Pokazuje jego wczesne lata wśród Jedi, jego relacje z nauczycielem, Yodą, oraz początki jego przemiany w mrocznego lorda Sithów.", Author = "Cavan Scott", isAvailable = true, CategoryId = 1, CopiesNumber = 1, CopiesAvailable = 1 },
                new Book { Id = 9, ImageUrl = "\\images\\mistrz-i-uczen-star-wars-b-iext146752016.jpg", Title = "Mistrz i uczeń", Description = "Książka ta opowiada historię Qui-Gon Jinn'a i jego padawana, Obi-Wana Kenobiego, przed wydarzeniami filmu \"Star Wars: Episode I - The Phantom Menace\". Skupia się na ich relacji mistrz-uczeń oraz ich wspólnych przygodach i wyzwaniach.", Author = "Claudia Gray", isAvailable = true, CategoryId = 1, CopiesNumber = 4, CopiesAvailable = 4 },
                new Book { Id = 10, ImageUrl = "\\images\\star-wars-bracia-b-iext149980208.jpg", Title = "Bracia", Description = "Ta powieść śledzi losy dwóch braci, Maula i Savage'a Opressów, którzy zostali oddzieleni przez okrutne losy i zmuszeni do walki o przetrwanie na różnych ścieżkach życia. Ich historie są splątane z intrygami Sithów i walką o władzę w galaktyce.", Author = "Mike Chen", isAvailable = true, CategoryId = 1, CopiesNumber = 9, CopiesAvailable = 9 },
                new Book { Id = 11, ImageUrl = "\\images\\it-b-iext137327068.jpg", Title = "It", Description = "Dzieci w małym miasteczku Derry w stanie Maine zaczynają znikać, a grupa przyjaciół staje w obliczu tajemniczej i przerażającej istoty, która przybiera różne formy, a która kryje się pod nazwą \"To\".", Author = "Stephen King", isAvailable = true, CategoryId = 3, CopiesNumber = 1, CopiesAvailable = 1 });
        }
    }
}
