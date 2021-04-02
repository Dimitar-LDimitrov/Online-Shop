namespace Shop.Application.StockAdmin
{
    using Shop.Database;
    using System.Collections.Generic;
    using System.Linq;

    public class GetStocks
    {
        private readonly ApplicationDbContext context;

        public GetStocks(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<StockViewModel> Do(int productId)
        {
            var stock = this.context.Stocks
                .Where(x => x.ProductId == productId)
                .Select(x => new StockViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    Quantity = x.Quantity
                })
                .ToList();

            return stock;
        }

        public class StockViewModel
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
        }
    }
}
