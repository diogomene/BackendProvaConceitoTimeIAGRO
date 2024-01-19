using BookAPIagro.DataAccess;
using System.Text.Json.Serialization;

namespace BookAPIagro.Entities
{
    public class BookDTO
    {
        [JsonPropertyName("id")]
        public uint Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("specifications")]
        public BookSpecs Specifications { get; set; } = new BookSpecs();

        public BookDTO() { }
        public BookDTO(Book book)
        {
            this.Id = book.Id;
            this.Name = book.Title;
            this.Price = book.Price;
            this.Specifications.Originally_published = book.PublishDate.ToString();
            this.Specifications.Author = book.Author.Select(a => a.Name).ToList();
            this.Specifications.Page_count = book.PageCount;
            this.Specifications.Illustrator = book.Illustrator.Select(i => i.Name).ToList();
            this.Specifications.Genres = book.Genre.Select(g => g.Name).ToList();
        }

        public Book ToBook()
        {
            List<Author> authors = this.Specifications.Author.Select(a => new Author(a)).ToList();
            List<Illustrator> illustrators = this.Specifications.Illustrator.Select(i => new Illustrator(i)).ToList();
            List<Genre> genres = this.Specifications.Genres.Select(g => new Genre(g)).ToList();
            return new Book(
                this.Id,
                this.Name,
                this.Price,
                DateOnly.Parse(this.Specifications.Originally_published),
                this.Specifications.Page_count,
                authors,
                illustrators,
                genres
            );
        }
    }

    public class BookSpecs
    {
        [JsonPropertyName("Originally published")]
        public string Originally_published { get; set; } = "";
        [JsonConverter(typeof(SingleOrArrayJSONConverter<string>))]
        public List<string> Author { get; set; } = [];
        [JsonPropertyName("Page count")]
        public uint Page_count { get; set; }
        [JsonConverter(typeof(SingleOrArrayJSONConverter<string>))]
        public List<string> Illustrator { get; set; } = [];
        [JsonConverter(typeof(SingleOrArrayJSONConverter<string>))]
        public List<string> Genres { get; set; } = [];
    }
}
