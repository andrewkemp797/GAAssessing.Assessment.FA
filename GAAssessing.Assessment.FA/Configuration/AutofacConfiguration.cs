using Autofac;
using AzureFunctions.Autofac.Configuration;
using GAAssessing.Assessment.FA.Components;
using GAAssessing.Models.Context;
using GAAssessing.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAAssessing.Assessment.FA.Configuration
{
    public class AutofacConfiguration
    {
        public AutofacConfiguration(string functionName)
        {
            DependencyInjection.Initialize(builder =>
            {
                builder.RegisterType<AssessmentComponent>().As<IAssessmentComponent>();
                builder.RegisterType<AssessingContext>().As<IAssessingContext>().WithParameter("connectionString", ConfigurationManager.ConnectionStrings["GAAssessing"].ConnectionString);
                builder.RegisterType<Repository>().As<IRepository>();
            }, functionName);
        }
    }
}
