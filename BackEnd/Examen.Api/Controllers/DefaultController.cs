using Microsoft.AspNetCore.Mvc;

namespace Examen.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        public DefaultController() { }

        [HttpGet]
        public string Index()
        {
            return "API Examen";
        }
    }
}
