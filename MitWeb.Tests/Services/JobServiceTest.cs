using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MITWeb.Models;
using MITWeb.Services;

namespace MitWeb.Tests.Services
{
    public class JobServiceTest
    {
        [Fact]
        public void TestGetJobs()
        {
            IJobService js = new JobService();
            IList<Job> jobList = js.GetJobs();
            Assert.NotEmpty(jobList);
        }
    }
}
