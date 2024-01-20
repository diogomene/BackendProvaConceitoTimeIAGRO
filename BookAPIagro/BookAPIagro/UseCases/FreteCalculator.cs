using BookAPIagro.Entities;

namespace BookAPIagro.UseCases
{
    public static class FreteCalculator
    {
        public static decimal CalculateFrete(this Book book) { 
            return book.Price * 0.2m;
        }
    }
}
