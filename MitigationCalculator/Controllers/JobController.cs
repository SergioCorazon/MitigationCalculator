using Microsoft.AspNetCore.Mvc;
using MitigationCalculator.Models;

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
            IEnumerable<Mitigation> voidList = Enumerable.Empty<Mitigation>();
            IEnumerable<Job> result =  Enumerable.Range(1, 4).Select(index => new Job(JobNameList[index-1], voidList)
            {
            })
          .ToArray();
            return result;


            //IEnumerable<Job> jobList;
            //Job jobWhm = new Job("Whithe Mage", new IEnumerable<Mitigacion>());
            //Job jobAst = new Job("Astrologian", new IEnumerable<Mitigacion>());
            //Job jobSch = new Job();
            //Job jobSge = new Job();
            //Job jobDrk = new Job();
            //Job jobPld = new Job();
            //Job jobGnb = new Job();
            //Job jobWar = new Job();
            //Job jobDnc = new Job();
            //Job jobMch = new Job();
            //Job jobBrd = new Job();
            //Job jobBlm = new Job();
            //Job jobRdm = new Job();
            //Job jobSmn = new Job();
        }
    }
}