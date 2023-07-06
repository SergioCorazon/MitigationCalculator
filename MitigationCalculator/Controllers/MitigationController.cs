using Microsoft.AspNetCore.Mvc;
using MitigationCalculator.Models;
using Newtonsoft.Json;

//TODO: ADD COMMENTS!

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
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\Assets\Mitigations.json");
            string filePath = Path.GetFullPath(sFile);
            using StreamReader reader = new(filePath);
            var json = reader.ReadToEnd();
            List<Mitigation>? mitigationshollyfuck = JsonConvert.DeserializeObject<List<Mitigation>>(json);
            if (mitigationshollyfuck is not null) return mitigationshollyfuck;
            return new List<Mitigation>();
        }

    }
}