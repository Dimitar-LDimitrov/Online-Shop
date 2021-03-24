namespace Shop.Application.ProductsAdmin
{
    using Shop.Database;
    using System.Threading.Tasks;

    public class UpdateProduct
    {
        private readonly ApplicationDbContext context;

        public UpdateProduct(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Response> Do(Request vm)
        {
            await this.context.SaveChangesAsync();
            return new Response();
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
