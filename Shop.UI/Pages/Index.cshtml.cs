namespace Shop.UI.Pages
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Shop.Application.ProductsAdmin;
    using Shop.Database;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public CreateProduct.Request Product { get; set; }

        public IEnumerable<GetProducts.ProductViewModel> Products { get; set; }

        public void OnGet()
        {
            this.Products = new GetProducts(this.context).Do();
        }

        public async Task<IActionResult> OnPost()
        {
            await new CreateProduct(this.context).Do(this.Product);

            return RedirectToPage("Index");
        }
    }
}
