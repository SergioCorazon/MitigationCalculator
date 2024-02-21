using Microsoft.AspNetCore.Mvc;
using MITWeb.Models;
using MITWeb.Services;
using Newtonsoft.Json;

//TODO: ADD COMMENTS!

namespace MITWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MitigationController : ControllerBase
    {
        private readonly ILogger<MitigationController> _logger;

        public MitigationController(ILogger<MitigationController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IList<Mitigation> Get()
        //{
        //    MitigationService service = new MitigationService();
        //    return service.GetAllMitigations();
        //}
        [HttpGet]
        public string Get()
        {
            MitigationService service = new MitigationService();
            return service.ReadMitigationFromJsonAndInsertIntoSQL();
        }
    }
}