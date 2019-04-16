using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AzureFunctions.Autofac;
using GAAssessing.Assessment.FA.Components;
using GAAssessing.Assessment.FA.Configuration;
using GAAssessing.Models.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace GAAssessing.Assessment.FA.Functions
{
    [DependencyInjectionConfig(typeof(AutofacConfiguration))]
    public static class AssessmentFunction
    {
        [FunctionName("AddAssessment")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "Assessment/AddAssessment")]HttpRequestMessage req, 
            TraceWriter log, [Inject] IAssessmentComponent component)
        {
            try
            {
                log.Info("Adding Assessment.");

                //read req body
                var content = await req.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(content))
                    req.CreateResponse(HttpStatusCode.BadRequest, "No content supplied.");

                //Deserialize body
                var assessment = JsonConvert.DeserializeObject<MotorAssessorReport>(content);

                //add assessment
                await component.AddAssessment(assessment);

                return req.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex, System.Reflection.MethodInfo.GetCurrentMethod().Name);
                return req.CreateResponse(HttpStatusCode.InternalServerError, "Something happened");
            }
            
        }
    }
}
