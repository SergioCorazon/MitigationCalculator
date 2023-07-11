using Microsoft.AspNetCore.Mvc;
using MitigationCalculator.Models;
using MitigationCalculator.Services;
using System;
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
            IList<Job> finalJobList = new List<Job>();
            //TODO: DO IT WITH FOREACHS OR DO WHILES OR WHATEVER A LOOP
            //finalJobList = jobList.Select(i => new Job
            //       (i.JobName,
            //        mitigationList.Select(j => new Mitigation(j.Name)
            //        {
            //            Name = j.Name,
            //            BossFlatDDownPerc = j.BossFlatDDownPerc,
            //            BossMagicDDownPerc = j.BossMagicDDownPerc,
            //            BossPhysicalDDownPerc = j.BossPhysicalDDownPerc,
            //            PartyFlatDefPerc = j.PartyPhysicalDefPerc,
            //            PartyMagicDefPerc = j.PartyPhysicalDefPerc,
            //            PartyPhysicalDefPerc = j.PartyPhysicalDefPerc,
            //            Shield = j.Shield
            //        })
            //        .Where(k => i.Mitsnames.Contains(k.Name))
            //   )
            //)
            //   .ToArray();
            return finalJobList;
        }
    }
}