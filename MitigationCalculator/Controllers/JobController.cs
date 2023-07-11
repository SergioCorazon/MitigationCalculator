using Microsoft.AspNetCore.Mvc;
using MitigationCalculator.Models;
using MitigationCalculator.Services;
using System.Collections.Generic;

namespace MitigationCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private static readonly string[] JobNameList = new[]
        {
        "White Mage", "Black Mage", "Dragoon", "Dark Knight",
    };

        private readonly ILogger<JobController> _logger;

        public JobController(ILogger<JobController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Job> Get()
        {
            MitigationService mitigationService = new MitigationService();
            IList<Mitigation> mitigationList = mitigationService.GetDataFromJson();
            JobService jobService = new JobService();
            IList<SimplifiedJob> jobList = jobService.GetDataFromJson();

            return null;
        }
    }
}