
using Microsoft.AspNetCore.Mvc;

namespace Proj.Controllers
{
    public interface IDataControllerForTesting
    {
        public  Task<ActionResult> DummyDataRequest();

    }
}