using Microsoft.AspNetCore.Mvc;
using Product.Application.DTOs;
using Product.Application.Products.Queries.GetProducts;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : BaseController
    {
        [HttpGet(Name = "Products")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await Mediator.Send(new GetProductListQuery());

            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(new
                {
                    Message = result.Message,
                    Errors = result.Errors
                });
            }
        }

    }
}
