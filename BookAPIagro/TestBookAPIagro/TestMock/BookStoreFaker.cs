using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookAPIagro.DataStore;
using BookAPIagro.Entities;

namespace TestBookAPIagro.TestMock
{
    public class BookStoreFaker
    {
        public static void CreateBookStore()
        {
            BookStore.GetInstance().StoreList = new BookStoreList(
                [
                    new Book(
                        1,
                        "Journey to the Center of the Earth",
                        10.00m,
                        new DateOnly(1864, 11, 25),
                        183,
                        new List<Author> { new Author("Jules Verne") },
                        new List<Illustrator> { new Illustrator("Édouard Riou") },
                        new List<Genre>
                        {
                            new Genre("Science Fiction"),
                            new Genre("Adventure fiction")
                        }
                    ),
                    new Book(
                        2,
                        "20,000 Leagues Under the Sea",
                        10.10m,
                        new DateOnly(1870, 6, 20),
                        213,
                        new List<Author> { new Author("Jules Verne") },
                        new List<Illustrator>
                        {
                            new Illustrator("Édouard Riou"),
                            new Illustrator("Alphonse-Marie-Adolphe de Neuville")
                        },
                        new List<Genre> { new Genre("Adventure fiction") }
                    ),
                    new Book(
                        3,
                        "Harry Potter and the Goblet of Fire",
                        7.31m,
                        new DateOnly(2000, 7, 8),
                        636,
                        new List<Author> { new Author("J. K. Rowling") },
                        new List<Illustrator>
                        {
                            new Illustrator("Cliff Wright"),
                            new Illustrator("Mary GrandPré")
                        },
                        new List<Genre>
                        {
                            new Genre("Fantasy Fiction"),
                            new Genre("Drama"),
                            new Genre("Young adult fiction"),
                            new Genre("Mystery"),
                            new Genre("Thriller"),
                            new Genre("Bildungsroman")
                        }
                    ),
                    new Book(
                        4,
                        "Fantastic Beasts and Where to Find Them: The Original Screenplay",
                        11.15m,
                        new DateOnly(2016, 11, 18),
                        457,
                        new List<Author> { new Author("J. K. Rowling") },
                        new List<Illustrator> { new Illustrator("Cliff Wright") },
                        new List<Genre>
                        {
                            new Genre("Fantasy Fiction"),
                            new Genre("Contemporary fantasy"),
                            new Genre("Screenplay")
                        }
                    ),
                    new Book(
                        5,
                        "The Lord of the Rings",
                        6.15m,
                        new DateOnly(1954, 7, 29),
                        715,
                        new List<Author> { new Author("J. R. R. Tolkien") },
                        new List<Illustrator>
                        {
                            new Illustrator("Alan Lee"),
                            new Illustrator("Ted Nashmith"),
                            new Illustrator("J. R. R. Tolkien")
                        },
                        new List<Genre>
                        {
                            new Genre("Fantasy Fiction"),
                            new Genre("Adventure Fiction")
                        }
                    )
                ]
            );
        }
    }
}
