using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        public string Index() 
        {
            return "Running ..";
        }
    }
}
