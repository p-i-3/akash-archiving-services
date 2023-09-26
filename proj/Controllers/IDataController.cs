
using Microsoft.AspNetCore.Mvc;

namespace Proj.Controllers
{
    public interface IDataController
    {
        public  Task<ActionResult> DummyDataRequest();

    }
}