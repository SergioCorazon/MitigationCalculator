using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.Extensions.Configuration;
using MITWeb.Models;
using Newtonsoft.Json;

namespace MITWeb.Services
{
    public class JobService : IJobService
    {
        private IList<SimplifiedJob> jobSimplifiedList = new List<SimplifiedJob>();

        public JobService() {
            jobSimplifiedList = GetDataFromJson();
        }

        //Read jobs and do an instert of job and mitigations
        //Get the Job given a jobname.
        public string ReadJobFromJsonAndInstertIntoSQL()
        {
            IList<Job> auxList = new List<Job>();
            auxList = GetJobs();
            string sql = "INSERT INTO JOB(JOBNAME) VALUES";
            foreach (var aux in auxList)
            {
                sql += "('" + aux.Name + "'),";
            }

            sql = sql.Substring(0, sql.Length - 1) + ";";
            return sql;
        }
        public string Insertjobmitigation()
        {
            var connectionString = "Server=.\\MITSQLSERVER;Database=MITCALCULATOR;Integrated Security=SSPI";
            try
            {

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                MitigationService mitService = new MitigationService();

                SqlCommand eraser = new SqlCommand("DELETE FROM JOB_MITIGATION; DELETE FROM JOB; DELETE FROM MITIGATION; ", connection);

                eraser.ExecuteNonQuery();

                SqlCommand command2 = new SqlCommand(mitService.ReadMitigationFromJsonAndInsertIntoSQL(), connection);

                SqlCommand command = new SqlCommand(ReadJobFromJsonAndInstertIntoSQL(), connection);



                //using (IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                //{


                //    while (reader.Read())
                //    {

                //    }

                //}
                command2.ExecuteNonQuery();
                command.ExecuteNonQuery();

                SqlCommand readIDJobsCommand = new SqlCommand("SELECT * FROM JOB", connection);
                
                using (IDataReader reader = readIDJobsCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ID = reader.GetInt32(reader.GetOrdinal("JOBIDNUMBER"));
                        string Name = reader.GetString(reader.GetOrdinal("JOBNAME"));
                        jobSimplifiedList.Where(i => i.JobName.Equals(Name)).Select(i => i.JobID = ID).ToList();
                    }
                }

                SqlCommand readIDMitigationsCommand = new SqlCommand("SELECT * FROM MITIGATION", connection);

                using (IDataReader reader = readIDMitigationsCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ID = reader.GetInt32(reader.GetOrdinal("MITIDNUMBER"));
                        string Name = reader.GetString(reader.GetOrdinal("MITNAME"));
                        mitService.mitigationList.Where(i => i.Name.Equals(Name)).Select(i => i.mitID = ID).ToList();
                    }
                }

                SqlCommand insertJobMitsRelationships = new SqlCommand("", connection);
                string sqlinsertion = "";
                string sqlinsertionaux = " INSERT INTO JOB_MITIGATION VALUES ({0}, {1}); ";
                //INSERT INTO JOB_MITIGATION (JOBIDNUMBER, MITIDNUMBER) VALUES ("ÑASDH", "AÑOHF");

                foreach (var job in jobSimplifiedList)
                {
                    foreach (string mitName in  job.Mitsnames)
                    {
                        int mitID = mitService.mitigationList.Where(i => i.Name.Equals(mitName)).Select (i => i.mitID).FirstOrDefault();
                        sqlinsertion += string.Format(sqlinsertionaux, job.JobID.ToString(), mitID.ToString());
                    }
                }
                insertJobMitsRelationships.CommandText = sqlinsertion;
                insertJobMitsRelationships.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                //LogException("Failed to ExecuteScalar for " + procedureName, ex, parameters);
                throw;
            }
            return "Todo va bien";
        }
        //read job json

        //read SQL IDs

        //assemble in a string both IDs



    


        public SimplifiedJob GetASimplifiedJobByName(string name)
        {
            return jobSimplifiedList.Where(i => i.JobName == name).FirstOrDefault();
        }

        //LLamar al mitigation Service
        public IList<Job> GetJobs()
        {
            MitigationService mitservice = new MitigationService();
            return this.jobSimplifiedList.Select(i => new Job (i.JobName, mitservice.GetMitigationBySimplifiedJob(i))).ToList();
        }


        public IList<SimplifiedJob> GetDataFromJson() {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\Assets\simplifiedjoblist.json");
            string filePath = Path.GetFullPath(sFile);
            using StreamReader reader = new(filePath);
            var json = reader.ReadToEnd();
            List<SimplifiedJob>? mitigationshollyfuck = JsonConvert.DeserializeObject<List<SimplifiedJob>>(json);
            if (mitigationshollyfuck is not null) return mitigationshollyfuck;
            return new List<SimplifiedJob>();
        }
    }
}
