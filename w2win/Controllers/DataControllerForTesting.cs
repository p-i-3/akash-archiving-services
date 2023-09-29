using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proj.Models;
using Proj.Services;
using System.Text.Json;
namespace Proj.Controllers
{
    [ApiController]
    [Route("api/Data")]
    public class DataControllerForTesting : ControllerBase, IDataControllerForTesting
    {
        private readonly IMongoDbConnector _mongoConnector;
        private readonly IAkashApiConnector _akashApitConnector;
        public DataControllerForTesting(IMongoDbConnector mongoDbConnector, IAkashApiConnector akashApiConnector)
        {
            _mongoConnector = mongoDbConnector;
            _akashApitConnector = akashApiConnector;
        }
        [HttpGet]
        [Route("/send")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DummyDataRequest()
        {
            try
            {
                var batchId = Guid.NewGuid().ToString();
                var owners = await _akashApitConnector.GetOwnerData(batchId);
                var hosts = await _akashApitConnector.GetHostData(owners,batchId);
                await _mongoConnector.UploadOwners(owners);
                await _mongoConnector.UploadHosts(hosts);
                return Ok(JsonSerializer.Serialize(new { ow = owners, ho = hosts }));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }

        }
    }
}