namespace Shop.Application.ProductsAdmin
{
    using Shop.Database;
    using System.Linq;

    public class GetProduct
    {
        private readonly ApplicationDbContext context;

        public GetProduct(ApplicationDbContext context) 
        {
            this.context = context;
        }

        public ProductViewModel Do(int id)
        {
            return this.context.Products
                .Where(x => x.Id == id)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Value = x.Value,
                })
                .FirstOrDefault();
        }

        public class ProductViewModel
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }

            public decimal Value { get; set; }
        }
    }
}
