﻿using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.DifficultyLevel.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.DifficultyLevel.QueriesHandlers
{
    public class GetDifficultyLevelByIdHandler : IRequestHandler<GetDifficultyLevelById, DifficultyLevelDto>
    {
        private readonly IDifficultyLevelRepository _difficultyLevelRepository;

        public GetDifficultyLevelByIdHandler(IDifficultyLevelRepository difficultyLevelRepository)
        {
            _difficultyLevelRepository = difficultyLevelRepository;
        }
        public async Task<DifficultyLevelDto> Handle(GetDifficultyLevelById request, CancellationToken cancellationToken)
        {
            return await _difficultyLevelRepository.ReadByIdAsync(request.Id);
        }
    }
}