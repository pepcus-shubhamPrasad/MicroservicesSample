using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Application.DTOs;
using Product.Application.Products.Commands.CreateProduct;
using Product.Application.Products.Queries.GetProducts;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("[controller]")]  
    public class ProductController : BaseController
    {
        [Authorize]
        [HttpGet(Name = "Products")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await Mediator.Send(new GetProductListQuery());

            if (result.Succeeded)
            {
                return Ok(new
                {
                    Data = result.Data
                });
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

        [Authorize]
        [HttpPost(Name = "CreateProducts")]
        public async Task<IActionResult> CarateProducts([FromBody] CreateProductCommand command)
        {
            var result = await Mediator.Send(command);
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
