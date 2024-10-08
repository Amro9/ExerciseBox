﻿using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Services.Interface;
using exerciseBox.Application.Services.Models;
using exerciseBox.Application.UseCases.SchoolBranche.Queries;
using exerciseBox.Application.UseCases.SchoolLevels.Queries;
using exerciseBox.Application.UseCases.Schools.Commands;
using exerciseBox.Application.UseCases.Schools.Queries;
using exerciseBox.Application.UseCases.SchoolTypes.Queries;
using exerciseBox.Application.UseCases.Subject.Queries;
using exerciseBox.Application.UseCases.Teacher.Queries;
using exerciseBox.Rest.Controllers.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace exerciseBox.Rest.Controllers
{
    /// <summary>
    /// Controller für Schuloperationen.
    /// </summary>
    public class SchoolController : BaseController
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="SchoolController"/> Klasse.
        /// </summary>
        /// <param name="mediator">Der MediatR-Mediator.</param>
        public SchoolController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Holt alle Schulen.
        /// </summary>
        /// <returns>Eine Liste von <see cref="SchoolDto"/> Objekten.</returns>
        [HttpGet("Schools")]
        public async Task<IEnumerable<SchoolDto>> GetAllSchools()
        {
            try
            {
                return await _mediator.Send(new GetAllSchools());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Holt eine Schule anhand der ID.
        /// </summary>
        /// <param name="email">Die E-Mail der Schule.</param>
        /// <returns>Ein <see cref="SchoolDto"/> Objekt.</returns>
        [HttpGet("School/{id}")]
        public async Task<SchoolDto> GetSchoolById(string email)
        {
            try
            {
                return await _mediator.Send(new GetSchoolById { Email = email });
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Holt alle Schulzweige.
        /// </summary>
        /// <returns>Ein <see cref="IActionResult"/> mit der Liste von Schulzweigen.</returns>
        [HttpGet("branches")]
        public async Task<IActionResult> GetSchoolBranches()
        {
            try
            {
                var branches = await _mediator.Send(new GetAllSchoolBranches());
                return Ok(branches);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Holt alle Schulstufen.
        /// </summary>
        /// <returns>Ein <see cref="IActionResult"/> mit der Liste von Schulstufen.</returns>
        [HttpGet("levels")]
        public async Task<IActionResult> GetSchoolLevels()
        {
            try
            {
                var levels = await _mediator.Send(new GetAllSchoolLevels());
                return Ok(levels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Holt alle Schultypen.
        /// </summary>
        /// <returns>Ein <see cref="IActionResult"/> mit der Liste von Schultypen.</returns>
        [HttpGet("Types")]
        public async Task<IActionResult> GetAllSchoolTypes()
        {
            try
            {
                var types = await _mediator.Send(new GetAllSchoolTypes());
                return Ok(types);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Holt alle Lehrer einer Schule.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ein <see cref="IActionResult"/> mit den Lehrer einer Schule.</returns>
        [HttpGet("Teachers/{id}")]
        public async Task<IActionResult> GetSchoolTeachers(string id)
        {
            try
            {
                var teachers = await _mediator.Send(new GetTeachersBySchool { SchoolId = id });
                return Ok(new { teachers });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Holt alle Fächer einer Schule.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Subjects/{id}")]
        public async Task<IActionResult> GetSchoolSubjects(string id)
        {
            try
            {
                var subjects = await _mediator.Send(new GetSchoolSubjects { SchoolId = id });
                return Ok(new { value = subjects });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }

        /// <summary>
        /// Holt alle Schulzweige einer Schule.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Branches/{id}")] 
        public async Task<IActionResult> GetBranchesOfSchool(string id)
        {
            try
            {
                var branches = await _mediator.Send(new GetBranchesOfSchool { SchoolId = id });
                return Ok(new { value = branches });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ein Fehler ist aufgetreten. Bitte versuchen Sie es später erneut.");
            }
        }
    }
}
