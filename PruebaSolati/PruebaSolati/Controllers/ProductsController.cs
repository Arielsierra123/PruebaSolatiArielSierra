using Businees.Models;
using Businees.Services;
using Microsoft.AspNetCore.Mvc;

namespace PruebaSolati.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        // GET: Products
        [HttpGet]
        public async Task<IActionResult> Products()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        // GET: Products/Detail/5
        [HttpGet("/api/[controller]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.GetProductDetail(id);
                return Ok(product);
            }

            return BadRequest();
        }

        // POST: Products/Create
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {

            if (ModelState.IsValid)
            {
                var result = await _productService.CreateProduct(productViewModel);
                return Ok(result == 1 ? true : false);
            }

            return BadRequest();
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        public async Task<IActionResult> Edit(int id,ProductViewModel productViewModel)
        {

            if (ModelState.IsValid)
            {
                var result = await _productService.EditProduct(id,productViewModel);
                return Ok(result == 1 ? true : false);
            }

            return BadRequest();
        }

        // Delete: Products/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.DeleteProduct(id);
                return Ok(result == 1 ? true: false);
            }

            return BadRequest();
        }
    }
}
