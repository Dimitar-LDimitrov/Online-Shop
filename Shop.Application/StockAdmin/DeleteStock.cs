namespace Shop.Application.StockAdmin
{
    using Shop.Database;
    using System.Linq;
    using System.Threading.Tasks;

    public class DeleteStock
    {
        private readonly ApplicationDbContext context;

        public DeleteStock(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Do(int id)
        {
            var stock = this.context.Stocks.FirstOrDefault(x => x.Id == id);

            this.context.Remove(stock);

            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
