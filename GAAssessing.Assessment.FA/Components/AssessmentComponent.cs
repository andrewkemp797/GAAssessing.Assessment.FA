using GAAssessing.Models.Context;
using GAAssessing.Models.Helpers;
using GAAssessing.Models.Models;
using GAAssessing.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAAssessing.Assessment.FA.Components
{
    public class AssessmentComponent : IAssessmentComponent
    {
        private readonly IRepository _repo;

        public AssessmentComponent(IRepository repo)
        {
            this._repo = repo;
        }

        public async Task<List<MotorAssessorReport>> ListAssessments()
        {
            var result = await _repo.GetAllAsync<MotorAssessorReport>(includes: new System.Linq.Expressions.Expression<Func<MotorAssessorReport, object>>[]
            {
                (m) => m.VehicleCondition
            });

            return SerializationHelper.ProcessEntity(result.ToList());
        }

        public async Task<List<MotorAssessorReport>> GetAssessmentById(int id)
        { 
            var result = await _repo.GetAsync<MotorAssessorReport>(
                filter: a => a.Id == id,
                includes: new System.Linq.Expressions.Expression<Func<MotorAssessorReport, object>>[]
                {
                    (m) => m.VehicleCondition
                });

            return SerializationHelper.ProcessEntity(result.ToList());
        }

        public async Task AddAssessment(MotorAssessorReport assessment)
        {
            _repo.Create(assessment);
            await _repo.SaveAsync();
        }
    }
}
