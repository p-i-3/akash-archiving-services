using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
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
        public DataController(IMongoDbConnector mongoDbConnector)
        {
            _mongoConnector = mongoDbConnector;
        }
        [HttpGet]
        [Route("/hosts/get/all")]
        [ProducesResponseType(typeof(HostDto), StatusCodes.Status200OK)]
        public async Task<ActionResult> HostDataRequestAll()
        {
            try
            {
                var stupidData = await _mongoConnector.GetHosts();
                return Ok(stupidData);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                return NotFound();
            }

        }
        [HttpGet]
        [Route("/hosts/get/active")]
        [ProducesResponseType(typeof(HostDto), StatusCodes.Status200OK)]
        public async Task<ActionResult> HostDataRequestActive()
        {
            try
            {
                var stupidData = await _mongoConnector.GetActiveHosts();
                return Ok(stupidData);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                return NotFound();
            }

        }
        [HttpGet]
        [Route("/owners/get/all")]
        [ProducesResponseType(typeof(OwnerDto), StatusCodes.Status200OK)]
        public async Task<ActionResult> OwnerDataRequestAll()
        {
            try
            {
                var stupidData = await _mongoConnector.GetOwners();
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