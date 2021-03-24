namespace Shop.UI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Shop.Application.ProductsAdmin;
    using Shop.Database;
    using System.Threading.Tasks;

    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext context;

        public AdminController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("products")]
        public IActionResult GetProducts() => Ok(new GetProducts(this.context).Do());

        [HttpGet("products/{id}")]
        public IActionResult GetProduct(int id) => Ok(new GetProduct(this.context).Do(id));

        [HttpPost("products")]
        public async  Task<IActionResult> CreateProduct([FromBody] CreateProduct.Request request) => 
            Ok((await new CreateProduct(this.context).Do(request)));

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(int id) => Ok((await new DeleteProduct(this.context).Do(id)));

        [HttpPut("products")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProduct.Request request) => 
            Ok((await new UpdateProduct(this.context).Do(request)));
    }
}
