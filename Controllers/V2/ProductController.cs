using ApiVersioning.DTOs.V1;
using ApiVersioning.DTOs.V2;
using ApiVersioning.Models;
using ApiVersioning.Services;
using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers.V2
{
    [ApiController]
    [ApiVersion(2.0)]
    [Route("api/v{version:apiVersion}/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductV2Dto> GetProduct(int id)
        {
            Product? product = _service.GetProducts()
                .FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var productDto = new ProductV2Dto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                
            };

            return Ok(productDto);
        }
    }
}
