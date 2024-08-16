using Microsoft.AspNetCore.Mvc;
using Store.Application.Services;
using Store.Contracts;
using Store.Core.Models;

namespace Store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productsService;
        private readonly IImageService _imageService;
        public ProductsController(IProductService productService, IImageService imageService)
        {
            _productsService = productService;
            _imageService = imageService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductsResponse>>> GetProducts()
        {
            var products = await _productsService.GetAllProducts();

            var response = products.Select(b => new ProductsResponse(b.Id, b.Title, b.Description, b.Price, b.Image.FileName));

            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] ProductsRequest request)
        {
            var product = Product.Create(Guid.NewGuid(), request.Title, request.Description, request.Price);

            if (product.IsFailure)
            {
                return BadRequest(product.Error);
            }

            var image = Image.Create(Guid.NewGuid(), "https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png", product.Value);

            if (image.IsFailure)
            {
                return BadRequest(image.Error);
            }

            product.Value.SetImage(image.Value);

            var productId = await _productsService.CreateProduct(product.Value);

            return Ok(productId);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateProducts(Guid id, [FromBody] ProductsRequest request)
        {
            var productId = await _productsService.UpdateProduct(id, request.Title, request.Description, request.Price);

            return Ok(productId);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteProduct(Guid id)
        {
            return Ok(await _productsService.DeleteProduct(id));
        }
    }
}