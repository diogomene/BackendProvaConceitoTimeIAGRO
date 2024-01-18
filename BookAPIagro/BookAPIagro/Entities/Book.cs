namespace BookAPIagro.Entities
{
    public class Book
    {
        public uint Id { get; private set; }
        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public DateOnly PublishDate { get; private set; }
        public int PageCount { get; private set; }
        public Author[] Author { get; private set; }
        public Illustrator[] Illustrator { get; private set; }
        public Genre[] Genre { get; private set; }
    }
}
