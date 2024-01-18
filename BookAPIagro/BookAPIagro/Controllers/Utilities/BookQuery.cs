using BookAPIagro.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookAPIagro.Controllers.Utilities
{
    public class BookQuery
    {
        [FromQuery (Name = "title")]
        public string? Title { get; set; }
        [FromQuery(Name = "price")]
        public decimal? Price { get; set; }
        [FromQuery(Name = "startPublishDate")]
        public DateTime? StartPublishDate { get; set; } = new DateTime();
        [FromQuery(Name = "endPublishDate")]
        public DateTime? EndPublishDate { get; set; } = new DateTime();
        [FromQuery(Name = "pageCount")]
        public int? PageCount { get; set; }
        [FromQuery(Name = "author")]
        public List<string>? Author { get; set; } = [];
        [FromQuery(Name = "illustrator")]
        public List<string>? Illustrator { get; set; } = [];
        [FromQuery(Name = "genre")]
        public List<string>? Genre { get; set; } = [];

    }
}
