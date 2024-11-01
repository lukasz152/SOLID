using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MySpot.Infrastructure;
using System.Globalization;

namespace MySpot.Api.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        private readonly string _name;
        //private readonly IConfiguration _configuration;


        //IOptionsSnapshot zapisuje na beizac jka sie zmieni applicaiton.json 
        public HomeController(IOptions<AppOptions> options)  //IConfiguratio dopeiro sie do plikow konfguracyjnych 
        {
            _name = options.Value.Name;
        }

        [HttpGet]
        public ActionResult<string> Get() => _name;
    
    }
}
