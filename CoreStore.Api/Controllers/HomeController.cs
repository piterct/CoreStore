using Microsoft.AspNetCore.Mvc;

namespace CoreStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        [Route("rota/01")]
        public object Get()
        {
            return new { version = "Version 0.0.1" };
        }
    }
}
