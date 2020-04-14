using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace SPA.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private static readonly string AppVersion = "KodotiApp-" + DateTime.UtcNow.ToString("yyyyMMddHHmmss");

        public ConfigController(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult Index() 
        {
            return Ok(
                new { 
                    ApiUrl = _configuration.GetValue<string>("ApiUrl")
                }
            );
        }

        [HttpGet("version")]
        public ActionResult GetVersion()
        {
            return Ok(AppVersion);
        }
    }
}
