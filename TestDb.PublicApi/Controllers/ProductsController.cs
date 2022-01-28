using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestDb.ApplicationCore;
using TestDb.PublicApi.Models;

namespace TestDb.PublicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ITestDbRepository<Product> repository;

        public ProductsController(ITestDbRepository<Product> _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetList(CancellationToken cancellationToken)
        {
            return await repository.ListAllAsync(cancellationToken);
        }

        [HttpPost]
        public async Task<Product> Create([FromBody] ProductBindingTarget request, CancellationToken cancellationToken)
        {
            Product product = request.ToProduct();
            var responce = await repository.AddAsync(product, cancellationToken);
            return responce;
        }

        [HttpPut]
        public async Task Update([FromBody] ProductUpdateBindingTarget request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;

            var existingProduct = await repository.GetByIdAsync(id, cancellationToken);
            existingProduct.UpdateDetails(request.Name, request.Description);

            await repository.UpdateAsync(existingProduct, cancellationToken);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var itemToDelete = await repository.GetByIdAsync(id, cancellationToken);
            if (itemToDelete is null) return NotFound();

            await repository.DeleteAsync(itemToDelete, cancellationToken);

            return Ok("Deleted");
        }


    }
}
