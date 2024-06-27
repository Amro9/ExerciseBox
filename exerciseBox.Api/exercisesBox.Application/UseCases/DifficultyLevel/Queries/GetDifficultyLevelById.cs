using exerciseBox.Application.Abtraction.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.DifficultyLevel.Queries
{
    public class GetDifficultyLevelById : IRequest<DifficultyLevelDto>
    { 
        public string Id { get; set; }
        public GetDifficultyLevelById(string id)
        {
                
            Id = id;
        }
    }
}
