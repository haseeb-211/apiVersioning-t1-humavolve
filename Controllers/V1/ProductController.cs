
using ApiVersioning.DTOs.V1;
using ApiVersioning.Models;
using ApiVersioning.Services;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers.V1
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductV1Dto> GetProduct(int id)
        {
            Product? product = _service.GetProducts()
                .FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var productDto = new ProductV1Dto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            return Ok(productDto);
        }
    }
}