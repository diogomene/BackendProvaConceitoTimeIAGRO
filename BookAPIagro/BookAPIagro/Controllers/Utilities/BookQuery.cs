using BookAPIagro.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookAPIagro.Controllers.Utilities
{
    public class BookQuery
    {
        public string? Title { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public DateTime? StartPublishDate { get; set; } = new DateTime();
        public DateTime? EndPublishDate { get; set; } = new DateTime();
        public uint? MinPageCount { get; set; }
        public uint? MaxPageCount { get; set; }
        public List<string>? Author { get; set; } = [];
        public List<string>? Illustrator { get; set; } = [];
        public List<string>? Genre { get; set; } = [];
    }
}
