namespace Shop.Application.ProductsAdmin
{
    using Shop.Database;
    using System.Linq;
    using System.Threading.Tasks;

    public class DeleteProduct
    {
        private readonly ApplicationDbContext context;

        public DeleteProduct(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Do(int id)
        {
            var product = this.context.Products
                .FirstOrDefault(p => p.Id == id);

            this.context.Products.Remove(product);

            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
