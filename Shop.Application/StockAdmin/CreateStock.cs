namespace Shop.Application.StockAdmin
{
    using Shop.Database;
    using Shop.Domain.Models;
    using System.Threading.Tasks;

    public class CreateStock
    {
        private readonly ApplicationDbContext context;

        public CreateStock(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Response> Do(Request request)
        {
            var stock = new Stock
            {
                Description = request.Description,
                ProductId = request.ProductId,
                Quantity = request.Quantity
            };

            this.context.Add(stock);

            await this.context.SaveChangesAsync();

            return new Response
            {
                Id = stock.Id,
                Description = stock.Description,
                Quantity = stock.Quantity
            };
        }

        public class Request
        {
            public int ProductId { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
        }
    }
}
