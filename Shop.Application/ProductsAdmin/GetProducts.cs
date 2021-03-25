namespace Shop.Application.ProductsAdmin
{
    using Shop.Database;
    using System.Collections.Generic;
    using System.Linq;

    public class GetProducts
    {
        private readonly ApplicationDbContext context;

        public GetProducts(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProductViewModel> Do()
        {
            return this.context.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Value = x.Value,
            });
        }

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Value { get; set; }
        }
    }
}
