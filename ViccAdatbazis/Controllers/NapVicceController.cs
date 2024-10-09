using Microsoft.AspNetCore.Mvc;

namespace ViccAdatbazis.Controllers
{
    public class NapVicceController : ControllerBase
    {
        [HttpGet]
        [Route("[controller]")]
        public string Get()
        {
            return "";
        }
    }
}
