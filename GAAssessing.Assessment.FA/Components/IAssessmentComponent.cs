using GAAssessing.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAAssessing.Assessment.FA.Components
{
    public interface IAssessmentComponent
    {
        Task AddAssessment(MotorAssessorReport assessment);
    }
}
