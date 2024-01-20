using BookAPIagro.UseCases;

namespace BookAPIagro.Entities
{
    public class Book(uint id, string title, decimal price, DateOnly publishDate, uint pageCount, List<Author> author, List<Illustrator> illustrator, List<Genre> genre)
    {
        public uint Id { get; private set; } = id;
        public string Title { get; private set; } = title;
        public decimal Price { get; private set; } = price;
        public DateOnly PublishDate { get; private set; } = publishDate;
        public uint PageCount { get; private set; } = pageCount;
        public List<Author> Author { get; private set; } = author;
        public List<Illustrator> Illustrator { get; private set; } = illustrator;
        public List<Genre> Genre { get; private set; } = genre;
        public decimal Frete => this.CalculateFrete();
    }


}
