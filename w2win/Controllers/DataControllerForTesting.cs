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
        public DataControllerForTesting(IMongoDbConnector mongoDbConnector,IAkashApiConnector akashApiConnector){
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
                var stupidData = await _akashApitConnector.GetDummyData();
                await _mongoConnector.UploadDummyData(stupidData);
                return Ok(stupidData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }

        }
    }
}