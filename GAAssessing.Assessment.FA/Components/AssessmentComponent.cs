using GAAssessing.Models.Context;
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

        public async Task AddAssessment(MotorAssessorReport assessment)
        {
            _repo.Create(assessment);
            await _repo.SaveAsync();
        }
    }
}
