using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Services;
using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.UseCases.Folder.Commands;
using exerciseBox.Application.UseCases.Questions.Commands;
using exerciseBox.Application.UseCases.Questions.Queries;
using exerciseBox.Rest.Controllers.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace exerciseBox.Rest.Controllers
{
    /// <summary>
    /// Controller für Fragenoperationen.
    /// </summary>
    public class QuestionController : BaseController
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="QuestionController"/> Klasse.
        /// </summary>
        /// <param name="mediator">Der MediatR-Mediator.</param>
        public QuestionController(IMediator mediator) : base(mediator)
        {

        }

        /// <summary>
        /// Speichert eine Frage in einem Ordner.
        /// </summary>
        /// <param name="request">Die Anfrage zum Speichern der Frage.</param>
        /// <returns>Eine <see cref="IActionResult"/> Rückgabe.</returns>
        [HttpPost("saveQuestionToFolder")]
        public async Task<IActionResult> SaveQuestionToFolder([FromBody] SaveQuestionToFolderRequest request)
        {
            try
            {
                await _mediator.Send(
                    new SaveQuestionToFolder(
                        request.JunctionId.ToString(), request.FolderId, request.QuestionId
                        ));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ein Problem ist aufgetreten: {ex.Message}");
            }
        }

        /// <summary>
        /// Fügt eine neue Frage hinzu.
        /// </summary>
        /// <param name="question">Die Frage, die hinzugefügt werden soll.</param>
        /// <returns>Eine <see cref="IActionResult"/> Rückgabe.</returns>
        [HttpPost("addQuestion")]
        public async Task<IActionResult> AddQuestion([FromBody] QuestionDto question)
        {
            try
            {
                var validationContext = new ValidationContext(question);
                Validator.ValidateObject(question, validationContext);

                var newQuestion = await _mediator.Send(new CreateQuestion { Question = question });
                await _mediator.Send(new AddQuestionToCreationFolder { Question = newQuestion });
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest($"Validierungsfehler: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ein Problem ist aufgetreten: {ex.Message}");
            }
        }

        /// <summary>
        /// Sucht Fragen basierend auf Suchparametern.
        /// </summary>
        /// <param name="parameters">Die Suchparameter.</param>
        /// <returns>Eine <see cref="IActionResult"/> Rückgabe mit den gefundenen Fragen.</returns>
        [HttpGet("SearchQuestions")]
        public async Task<IActionResult> SearchQuestions([FromQuery] QuestionSearchParamsRequest parameters)
        {
            try
            {
                IEnumerable<QuestionDto> questions;

                if (!string.IsNullOrEmpty(parameters.Subject))
                {
                    questions = await _mediator.Send(new GetPublicQuestionsBySubject(parameters.Subject));
                }
                else
                {
                    questions = await _mediator.Send(new GetAllPublicQuestions());
                }

                var filteredQuestions = QuestionsFilter.Filter(questions, parameters);

                var hiddenQuestions = await _mediator.Send(new GetHiddenQuestionsByTeacher(parameters.TeacherEmail));

                filteredQuestions = QuestionsFilter.FilterHiddenQuestions(filteredQuestions, hiddenQuestions);

                return Ok(filteredQuestions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ein Problem ist aufgetreten: {ex.Message}");
            }
        }
        [HttpPut("hideQuestionByTeacher")]
        public async Task<IActionResult> HideQuestionByTeacher([FromBody] HideQuestionRequest request)
        {

            // Beispiel: this.questionService.HideQuestion(questionId, request.Days);
            try { 
            bool isHidden = await _mediator.Send(new HideQuestionByTeacher (request.QuestionId , request.TeacherId));
            return Ok(new { message = "Frage erfolgreich ausgeblendet." });
            }catch
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }


        /// <summary>
        /// Holt Fragen eines bestimmten Ordners.
        /// </summary>
        /// <param name="folderId">Die ID des Ordners.</param>
        /// <returns>Eine <see cref="IActionResult"/> Rückgabe mit den Fragen des Ordners.</returns>
        [HttpGet("folderQuestions/{folderId}")]
        public async Task<IActionResult> GetFolderQuestions(string folderId)
        {
            try
            {
                var questions = await _mediator.Send(new GetFolderQuestions { FolderId = folderId });
                return Ok(new { value = questions });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ein Problem ist aufgetreten: {ex.Message}");
            }
        }
    }
}
