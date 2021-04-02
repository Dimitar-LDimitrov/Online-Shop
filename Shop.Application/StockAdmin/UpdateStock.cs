namespace Shop.Application.StockAdmin
{
    using Shop.Database;
    using Shop.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UpdateStock
    {
        private readonly ApplicationDbContext context;

        public UpdateStock(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Response> Do(Request request)
        {
            var stocks = new List<Stock>();

            foreach (var stock in request.Stock)
            {
                stocks.Add(new Stock
                {
                    Id = stock.Id,
                    Description = stock.Description,
                    ProductId = stock.ProductId,
                    Quantity = stock.Quantity
                });
            }

            this.context.Stocks.UpdateRange(stocks);

            await this.context.SaveChangesAsync();

            return new Response
            {
                Stock = request.Stock
            };
        }

        public class StockViewModel
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
        }

        public class Request
        {
            public IEnumerable<StockViewModel> Stock { get; set; }
        }

        public class Response
        {
            public IEnumerable<StockViewModel> Stock { get; set; }
        }
    }
}
