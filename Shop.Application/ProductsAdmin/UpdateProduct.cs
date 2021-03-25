namespace Shop.Application.ProductsAdmin
{
    using Shop.Database;
    using System.Linq;
    using System.Threading.Tasks;

    public class UpdateProduct
    {
        private readonly ApplicationDbContext context;

        public UpdateProduct(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Response> Do(Request request)
        {
            var product = this.context.Products.FirstOrDefault(x => x.Id == request.Id);

            product.Name = request.Name;
            product.Description = request.Description;
            product.Value = request.Value;

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
            public int Id { get; set; }
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
