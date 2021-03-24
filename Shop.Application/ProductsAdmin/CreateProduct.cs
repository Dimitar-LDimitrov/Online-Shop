namespace Shop.Application.ProductsAdmin
{
    using Shop.Database;
    using Shop.Domain.Models;
    using System.Threading.Tasks;

    public class CreateProduct
    {
        private readonly ApplicationDbContext context;

        public CreateProduct(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Response> Do(Request request)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Value = request.Value
            };

            this.context.Products.Add(product);

            await this.context.SaveChangesAsync();

            return new Response
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Value = product.Value
            };
        }

        public class Request
        {
            public string Name { get; set; }

            public string Description { get; set; }

            public decimal Value { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }

            public decimal Value { get; set; }
        }
    }
}
