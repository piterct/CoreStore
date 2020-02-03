using Microsoft.AspNetCore.Mvc;

namespace CoreStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public object Get()
        {
            return new { version = "Version 0.0.1" };
        }
    }
}
