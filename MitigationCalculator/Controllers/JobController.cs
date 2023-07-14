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

            //Recorrer cada elemento de la lista de jobs
            //Comparar los nombres de las mitigaciones de cada job con los de MitList
            //crear un objeto de job por cada simplified job
            //volcar los datos del simplified job y de las mitigaciones del mitlist en el objeto job.
            //Sustituir los mits de la lista con los datos de la mitlist
            //añadir el objeto job al listado de objetos job llamado final job list


            //foreach (SimplifiedJob i in jobList)
            //{
            //    Job tempJob = new Job();
            //    IList<Mitigation> tempMitigationList = new List<Mitigation>();
            //    foreach (string j in i.Mitsnames)
            //    {
            //        foreach (Mitigation k in mitigationList)
            //        {
            //            if (k.Name == j)
            //            {
            //                tempMitigationList.Add(k);
            //            }
            //        }
            //    }
            //    tempJob.Name = i.JobName;
            //    tempJob.Mitigations = tempMitigationList;
            //    finalJobList.Add(tempJob);
            //}

            //find the same mits on each list, mit and job.
            //replace the found simple mits for the complex mits on the new finaljoblist.

            finalJobList = jobList.Select(i => new Job(
                i.JobName, mitigationList.Where(j => i.Mitsnames.Contains(j.Name))
            )).ToArray();






















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