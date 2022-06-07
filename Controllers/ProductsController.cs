using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Shopee.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase {
    private static List<Products> products = new List<Products> {
        new Products { id = 1, name = "Coffee", description = "Its a coffee!", price = 10.00 },
        new Products { id = 2, name = "Milk", description = "Good for bones!", price = 20.00 },
        new Products { id = 3, name = "Tea", description = "Good for body!", price = 30.00 }
    };

    //This GET method will display all of the products stored in the list
    [HttpGet]
    public async Task<ActionResult<List<Products>>> Get() {
        return Ok(products);
    }

    //This GET methid will display a specific product using its id.
    [HttpGet("{id}")]
    public async Task<ActionResult<List<Products>>> Get(int id) {
        var product = products.Find(i => i.id == id);
        if(product == null) {
            return BadRequest("Product not found");
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<List<Products>>> AddProduct(Products product) {
        products.Add(product);
        return Ok(products);
    }

    [HttpPut]
    public async Task<ActionResult<List<Products>>> UpdateProduct(Products getProduct) {
        var product = products.Find(i => i.id == getProduct.id);
        if(product == null) {
            return BadRequest("Product not found");
        }

        product.name = getProduct.name;
        product.description = getProduct.description;
        product.price = getProduct.price;

        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Products>>> Delete(int id) {
        var product = products.Find(i => i.id == id);
        if(product == null) {
            return BadRequest("Product not found");
        }

        products.Remove(product);
        return Ok(product);
    }
}