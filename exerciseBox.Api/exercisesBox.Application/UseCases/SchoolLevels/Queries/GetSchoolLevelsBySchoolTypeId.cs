using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.SchoolLevels.Queries
{
    public class GetSchoolLevelsBySchoolTypeId : IRequest<IEnumerable<int>>
    {
        public int SchoolTypeId { get; set; }
        public GetSchoolLevelsBySchoolTypeId(int schoolTypeId)
        {
            SchoolTypeId = schoolTypeId;
        }
    }
}
