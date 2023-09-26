using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proj.Models;
using Proj.Services;
using System.Text.Json;
namespace Proj.Controllers
{
    [ApiController]
    [Route("api/Data")]
    public class DataController : ControllerBase, IDataController
    {
        private readonly IMongoDbConnector _mongoConnector;
        public DataController(IMongoDbConnector mongoDbConnector){
            _mongoConnector = mongoDbConnector;
        }
        [HttpGet]
        [Route("/get")]
        [ProducesResponseType(typeof(DummyData), StatusCodes.Status200OK)]
        public async Task<ActionResult> DummyDataRequest()
        {
            try
            {
                var stupidData = await _mongoConnector.GetDummyData();
                return Ok(stupidData);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                return NotFound();
            }

        }
    }
}