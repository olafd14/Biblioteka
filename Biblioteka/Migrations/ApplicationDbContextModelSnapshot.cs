﻿// <auto-generated />
using System;
using Biblioteka.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biblioteka.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Biblioteka.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CopiesAvailable")
                        .HasColumnType("int");

                    b.Property<int>("CopiesNumber")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfRatings")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("UserRating")
                        .HasColumnType("float");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 12,
                            Author = "Andrzej Sapkowski",
                            CategoryId = 2,
                            CopiesAvailable = 3,
                            CopiesNumber = 3,
                            Description = "Zbiór opowiadań, które wprowadzają czytelnika w świat wiedźmina Geralta z Rivii, przedstawiając jego przygody z różnymi potworami i ludźmi, a także ukazując złożoność świata, w którym żyje.",
                            ImageUrl = "\\images\\ostatnie-zyczenie-wiedzmin-tom-1-b-iext146796925.jpg",
                            NumberOfRatings = 0,
                            Title = "Ostatnie życzenie",
                            UserRating = 0.0,
                            isAvailable = true
                        },
                        new
                        {
                            Id = 13,
                            Author = "Andrzej Sapkowski",
                            CategoryId = 2,
                            CopiesAvailable = 4,
                            CopiesNumber = 4,
                            Description = "Kontynuacja przygód Geralta, który walczy z kolejnymi bestiami i stawia czoła moralnym dylematom, jednocześnie odkrywając coraz więcej tajemnic swojej przeszłości.",
                            ImageUrl = "\\images\\miecz-przeznaczenia-wiedzmin-tom-2-b-iext146798643.jpg",
                            NumberOfRatings = 0,
                            Title = "Miecz przeznaczenia",
                            UserRating = 0.0,
                            isAvailable = true
                        },
                        new
                        {
                            Id = 14,
                            Author = "Andrzej Sapkowski",
                            CategoryId = 2,
                            CopiesAvailable = 3,
                            CopiesNumber = 3,
                            Description = " Pierwsza powieść z serii, gdzie historia rozwija się w głębszy sposób, przedstawiając polityczne intrygi, konflikty międzyrasowe oraz losy Ciri, dziedziczki z rodu królewskiego.",
                            ImageUrl = "\\images\\krew-elfow-wiedzmin-tom-3-b-iext146807006.jpg",
                            NumberOfRatings = 0,
                            Title = "Krew elfów",
                            UserRating = 0.0,
                            isAvailable = true
                        },
                        new
                        {
                            Id = 4,
                            Author = "Andrzej Sapkowski",
                            CategoryId = 2,
                            CopiesAvailable = 6,
                            CopiesNumber = 6,
                            Description = "Główny wątek koncentruje się na poszukiwaniach Ciri oraz wydarzeniach politycznych w królestwach Północy, gdzie Geralt staje w obliczu nowych wrogów i wyzwań.",
                            ImageUrl = "\\images\\czas-pogardy-wiedzmin-tom-4-b-iext146808438.jpg",
                            NumberOfRatings = 0,
                            Title = "Czas pogardy",
                            UserRating = 0.0,
                            isAvailable = true
                        },
                        new
                        {
                            Id = 5,
                            Author = "Andrzej Sapkowski",
                            CategoryId = 2,
                            CopiesAvailable = 5,
                            CopiesNumber = 5,
                            Description = "Geralt i jego towarzysze wyruszają w kolejną niebezpieczną podróż, tym razem z zamiarem obrony Ciri przed jej przeznaczeniem, a także stawiając czoła coraz bardziej złożonym zagrożeniom.",
                            ImageUrl = "\\images\\chrzest-ognia-wiedzmin-tom-5-b-iext146808430.jpg",
                            NumberOfRatings = 0,
                            Title = "Chrzest ognia",
                            UserRating = 0.0,
                            isAvailable = true
                        },
                        new
                        {
                            Id = 6,
                            Author = "Andrzej Sapkowski",
                            CategoryId = 2,
                            CopiesAvailable = 3,
                            CopiesNumber = 3,
                            Description = "Główna akcja koncentruje się na rozstrzygnięciu losów Ciri, która znajduje się w centrum konfliktu między różnymi frakcjami, a także na decydującym starciu między siłami dobra i zła.",
                            ImageUrl = "\\images\\wieza-jaskolki-wiedzmin-tom-6-b-iext146806990.jpg",
                            NumberOfRatings = 0,
                            Title = "Wieża Jaskółki",
                            UserRating = 0.0,
                            isAvailable = true
                        },
                        new
                        {
                            Id = 7,
                            Author = "Andrzej Sapkowski",
                            CategoryId = 2,
                            CopiesAvailable = 3,
                            CopiesNumber = 3,
                            Description = "Finalna część sagi, w której wszystkie wątki i losy głównych bohaterów splatają się w epicki sposób, prowadząc do ostatecznego starcia między światłem a ciemnością.",
                            ImageUrl = "\\images\\pani-jeziora-wiedzmin-tom-7-b-iext146807615.jpg",
                            NumberOfRatings = 0,
                            Title = "Pani Jeziora",
                            UserRating = 0.0,
                            isAvailable = true
                        },
                        new
                        {
                            Id = 8,
                            Author = "Cavan Scott",
                            CategoryId = 1,
                            CopiesAvailable = 1,
                            CopiesNumber = 1,
                            Description = "Ta książka skupia się na młodym hrabim Dooku, który jest jeszcze uczniem w Zakonie Jedi. Pokazuje jego wczesne lata wśród Jedi, jego relacje z nauczycielem, Yodą, oraz początki jego przemiany w mrocznego lorda Sithów.",
                            ImageUrl = "\\images\\star-wars-dooku-stracony-dla-jedi-b-iext146760891.jpg",
                            NumberOfRatings = 0,
                            Title = "Dooku: Stracony dla Jedi",
                            UserRating = 0.0,
                            isAvailable = true
                        },
                        new
                        {
                            Id = 9,
                            Author = "Claudia Gray",
                            CategoryId = 1,
                            CopiesAvailable = 4,
                            CopiesNumber = 4,
                            Description = "Książka ta opowiada historię Qui-Gon Jinn'a i jego padawana, Obi-Wana Kenobiego, przed wydarzeniami filmu \"Star Wars: Episode I - The Phantom Menace\". Skupia się na ich relacji mistrz-uczeń oraz ich wspólnych przygodach i wyzwaniach.",
                            ImageUrl = "\\images\\mistrz-i-uczen-star-wars-b-iext146752016.jpg",
                            NumberOfRatings = 0,
                            Title = "Mistrz i uczeń",
                            UserRating = 0.0,
                            isAvailable = true
                        },
                        new
                        {
                            Id = 10,
                            Author = "Mike Chen",
                            CategoryId = 1,
                            CopiesAvailable = 9,
                            CopiesNumber = 9,
                            Description = "Ta powieść śledzi losy dwóch braci, Maula i Savage'a Opressów, którzy zostali oddzieleni przez okrutne losy i zmuszeni do walki o przetrwanie na różnych ścieżkach życia. Ich historie są splątane z intrygami Sithów i walką o władzę w galaktyce.",
                            ImageUrl = "\\images\\star-wars-bracia-b-iext149980208.jpg",
                            NumberOfRatings = 0,
                            Title = "Bracia",
                            UserRating = 0.0,
                            isAvailable = true
                        },
                        new
                        {
                            Id = 11,
                            Author = "Stephen King",
                            CategoryId = 3,
                            CopiesAvailable = 1,
                            CopiesNumber = 1,
                            Description = "Dzieci w małym miasteczku Derry w stanie Maine zaczynają znikać, a grupa przyjaciół staje w obliczu tajemniczej i przerażającej istoty, która przybiera różne formy, a która kryje się pod nazwą \"To\".",
                            ImageUrl = "\\images\\it-b-iext137327068.jpg",
                            NumberOfRatings = 0,
                            Title = "It",
                            UserRating = 0.0,
                            isAvailable = true
                        });
                });

            modelBuilder.Entity("Biblioteka.Models.BorrowHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BorrowTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserName");

                    b.ToTable("BorrowHistorys");
                });

            modelBuilder.Entity("Biblioteka.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Literatura science fiction wyróżnia się tym, że eksploruje fantastyczne światy, technologie i społeczeństwa, często w kontekście naukowych hipotez lub możliwych przyszłych scenariuszy. Ta kategoria literacka często skupia się na tematach związanych z przyszłością, podróżami kosmicznymi, sztuczną inteligencją, alternatywnymi rzeczywistościami i wpływem postępu technologicznego na ludzkość.",
                            Name = "Sci-fi"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Literatura fantastyczna to jeden z gatunków literackich, w przypadku którego fabuła zawiera, na przykład, elementy związane bezpośrednio z magią. Dla literatury fantasy charakterystyczne jest tworzenie miejsca zdarzeń nieistniejącego w rzeczywistym świecie.",
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Literatura horroru wyróżnia się tym, że stara się wywołać uczucie strachu, niepokoju i grozy u czytelnika. Często wykorzystuje napięcie, atmosferę oraz elementy nadprzyrodzone lub makabryczne, aby budować suspens i prowadzić do nieoczekiwanych zwrotów akcji. Horror eksploruje ludzkie lęki, tabu i obsesje, często konfrontując czytelnika z najgłębszymi mrocznymi stronami ludzkiej natury.",
                            Name = "Horror"
                        });
                });

            modelBuilder.Entity("Biblioteka.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserName");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Biblioteka.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<bool>("HasBorrowedBook")
                        .HasColumnType("bit");

                    b.HasIndex("BookId");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Biblioteka.Models.Book", b =>
                {
                    b.HasOne("Biblioteka.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Biblioteka.Models.BorrowHistory", b =>
                {
                    b.HasOne("Biblioteka.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteka.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserName");

                    b.Navigation("ApplicationUser");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Biblioteka.Models.Review", b =>
                {
                    b.HasOne("Biblioteka.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("Biblioteka.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserName");

                    b.Navigation("ApplicationUser");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Biblioteka.Models.ApplicationUser", b =>
                {
                    b.HasOne("Biblioteka.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}
