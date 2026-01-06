using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Skinet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected async Task<ActionResult> CreatePagedResult<T>(IGenericRepository<T> repository,
            ISpecification<T> specification, int pageIndex, int pageSize) where T : Core.Entities.Entity
        {
            var items = await repository.ListWithSpecification(specification);

            var totalItems = await repository.CountAsync(specification);

            var paginatedResult = new Core.Pagination.PaginationInformation<T>(pageIndex, pageSize, totalItems, items);

            return Ok(paginatedResult);
        }
    }
}
