using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Data;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        // GET /products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(ProductStore.Products);
        }

        // GET /products/{id}
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = ProductStore.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST /products
        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            product.Id = ProductStore.Products.Count > 0
                ? ProductStore.Products.Max(p => p.Id) + 1
                : 1;

            ProductStore.Products.Add(product);

            return CreatedAtAction(nameof(GetProduct),
                new { id = product.Id },
                product);
        }

        // PUT /products/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var product = ProductStore.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            return NoContent();
        }

        // DELETE /products/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = ProductStore.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            ProductStore.Products.Remove(product);

            return NoContent();
        }
    }
}