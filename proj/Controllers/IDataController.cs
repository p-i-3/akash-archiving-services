
using Microsoft.AspNetCore.Mvc;

namespace Proj.Controllers
{
    public interface IDataController
    {
        public  Task<ActionResult> OwnerDataRequestAll();
        public  Task<ActionResult> HostDataRequestAll();
        public  Task<ActionResult> HostDataRequestActive();

    }
}