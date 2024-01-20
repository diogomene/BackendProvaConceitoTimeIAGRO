using BookAPIagro.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookAPIagro.Controllers.Utilities
{
    public enum OrderType
    {
        [Description("Ascending Order")]
        Asc,
        [Description("Descending Order")]
        Desc
    }
    public class BookQuery
    {
        public string? Title { get; set; } = default;
        public decimal? MinPrice { get; set; } = default;
        public decimal? MaxPrice { get; set; } = default;
        public DateTime? StartPublishDate { get; set; } = default;
        public DateTime? EndPublishDate { get; set; } = default;
        public uint? MinPageCount { get; set; } = default;
        public uint? MaxPageCount { get; set; } 
        public List<string>? Author { get; set; } = default;
        public List<string>? Illustrator { get; set; } = default;
        public List<string>? Genre { get; set; } = default;
        public OrderType? orderPriceBy { get; set; } = default;
    }
}
