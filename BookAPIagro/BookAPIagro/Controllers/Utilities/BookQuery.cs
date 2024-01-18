using BookAPIagro.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookAPIagro.Controllers.Utilities
{
    public class BookQuery
    {
        [FromQuery (Name = "title")]
        public string? Title { get; set; }
        [FromQuery (Name = "price")]
        public decimal? Price { get; set; }
        [FromQuery (Name = "date")]
        public DateOnly? Date { get; set; }
        [FromQuery (Name = "pageCount")]
        public int? PageCount { get; set; }
        [FromQuery (Name = "author")]
        public string[]? Author { get; set; } = new string[] { };
        [FromQuery (Name = "illustrator")]
        public string[]? Illustrator { get; set; } = new string[] { };
        [FromQuery (Name = "genre")]
        public string[]? Genre { get; private set; } = new string[] { };
        

    }
}
