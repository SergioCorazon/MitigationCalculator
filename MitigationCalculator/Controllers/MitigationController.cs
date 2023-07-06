using Microsoft.AspNetCore.Mvc;
using MitigationCalculator.Models;

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
        public IList<Mitigation> Get()
        {
            IList<Mitigation> mitigationList = new List<Mitigation>();
            Mitigation feint = new Mitigation("Feint");
            feint.BossMagicDDownPerc = 5;
            feint.BossPhysicalDDownPerc = 10;
            mitigationList.Add(feint);
      
            return mitigationList;
        }
    }
}