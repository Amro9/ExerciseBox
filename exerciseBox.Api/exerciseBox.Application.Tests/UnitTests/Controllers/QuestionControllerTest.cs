using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.UseCases.Questions.Commands;
using exerciseBox.Rest.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace exerciseBox.Application.Tests.UnitTests.Controllers
{
    [TestClass]
    public class QuestionControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly QuestionController _questionController;

        public QuestionControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _questionController = new QuestionController(_mediatorMock.Object, null);
        }

        [TestMethod]
        public async Task AddQuestion_ReturnsOkResult()
        {
            // Arrange
            var questionDto = new QuestionDto()
            {
                Author = "LehrerId",
                QuestionText = "QuestionText",
                Answer = "AnswerId",
                SchoolLevel = 12,
                DifficultyLevel = "SchwierigkeitsId",
                Subject = "FachId",
                Topic = "ThemaId",
                QuestionIsPrivate = false
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateQuestion>(), default))
            .ReturnsAsync(questionDto);
            // Act
            var result = await _questionController.AddQuestion(questionDto);
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public async Task AddQuestion_ReturnsStatusCode500_WhenGeneralExceptionOccurs()
        {
            // Arrange
            var questionDto = new QuestionDto()
            {
                Author = "LehrerId",
                QuestionText = "QuestionText",
                Answer = "AnswerId",
                SchoolLevel = 12,
                DifficultyLevel = "SchwierigkeitsId",
                Subject = "FachId",
                Topic = "ThemaId",
                QuestionIsPrivate = false
            };
            _mediatorMock
            .Setup(m => m.Send(It.IsAny<CreateQuestion>(), default))
            .ThrowsAsync(new Exception("Datenbank exception"));

            // Act
            var result = await _questionController.AddQuestion(questionDto);

            // Assert
            var internalServerErrorResult = result as ObjectResult;
            Assert.AreEqual(500, internalServerErrorResult.StatusCode);
        }

        [TestMethod]
        public async Task AddQuestion_ReturnsBadRequest_WhenValidationExceptionOccurs()
        {
            //Arrange
            var questionDto = new QuestionDto()
            {
                Author = "LehrerId",
                QuestionText = "",
                Answer = "AnswerId",
                SchoolLevel = 12,
                DifficultyLevel = "SchwierigkeitsId",
                Subject = "FachId",
                Topic = "ThemaId",
                QuestionIsPrivate = false
            };
            _mediatorMock
            .Setup(m => m.Send(It.IsAny<CreateQuestion>(), default))
            .ThrowsAsync(new ValidationException("Test exception"));

            // Act
            var result = await _questionController.AddQuestion(questionDto);

            // Assert
            var badRequestResult = result as ObjectResult;
            Assert.AreEqual(400, badRequestResult.StatusCode);

        }
    }
}