using Microsoft.AspNetCore.Mvc;

//TODO: solve issues that break the application
//Return to the client the data of all avaible mitigations


namespace MitigationCalculator.Controllers
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

        [HttpGet]
        public IEnumerable<Mitigation> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Mitigation
            {
            })
            .ToArray();
        }
    }
}