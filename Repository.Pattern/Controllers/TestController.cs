using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Repository.Pattern.BLL.Services;
using Repository.Pattern.Common.Options;
using Repository.Pattern.DAL.Entities;

namespace Repository.Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ConnectionStrings _connectionStrings;
        private readonly IExampleService _exampleService;

        public TestController(
            IOptions<ConnectionStrings> connectionStrings,
            IExampleService exampleService
        )
        {
            _exampleService = exampleService;
            _connectionStrings = connectionStrings.Value;
        }

        /// <summary>
        /// Request for obtaining full information about one of the entities
        /// </summary>
        /// <param name="id">Entity GUID</param>
        /// <returns>Necessary entity (ExampleEntity Type)</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var result = await _exampleService.GetByIdAsync(id);

            return Ok(result);
        }

        /// <summary>
        /// Request for creating new entity
        /// </summary>
        /// <param name="entity">Whole information about new entity</param>
        /// <returns>Created entity (ExampleEntity Type)</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExampleEntity entity)
        {
            var result = await _exampleService.CreateAsync(entity);

            return Ok(result);
        }
    }
}