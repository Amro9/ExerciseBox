﻿using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Questions.Queries;

    public class GetAllPublicQuestions : IRequest<IEnumerable<QuestionDto>>
    {
        
    }
