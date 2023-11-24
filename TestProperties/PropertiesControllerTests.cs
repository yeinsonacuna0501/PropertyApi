using Moq;
using NUnit.Framework;
using Property.Api.Controllers;
using Property.Application.UseCase.UseCases.Property.Commands;
using Property.Application.UseCase.UseCases.Property.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.IO;
using System;
using MediatR;
using Property.Application.UseCase.UseCases.Property.Commands.CreateCommand;
using Property.Application.UseCase.UseCases.Property.Commands.AddImageCommand;
using Property.Application.UseCase.UseCases.Property.Commands.ChangePriceCommand;
using Property.Application.UseCase.UseCases.Property.Commands.UpdateCommand;
using Property.Application.UseCase.UseCases.Property.Queries.GetFilterQuery;
using Property.Application.UseCase.Commons.Bases;
using Property.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Property.Application.Dtos.Property.Response;

namespace Property.Api.Tests.Controllers
{
    [TestFixture]
    public class PropertyControllerTests
    {
        private Mock<IMediator> _mediatorMock;
        private Mock<IConfiguration> _configurationMock;

        [SetUp]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _configurationMock = new Mock<IConfiguration>();
        }

        [Test]
        public async Task RegisterProperty_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            _configurationMock.Setup(config => config.GetSection("Configuration").GetSection("RouteServer").Value);
            var controller = new PropertyController(_mediatorMock.Object, _configurationMock.Object);
            var command = new CreatePropertyCommand
            {
                Name = "Property Prueba",
                Address = "Calle prueba",
                Price = 100000000,
                CodeInternal = "ABC123",
                YearProperty = 2023,
                IdOwner = 1 
            };
            var mockResponse = new BaseResponse<bool>
            {
                IsSuccess = true,
                Data = true, 
                Message = GlobalMessages.MESSAGE_SAVE
            };
            _mediatorMock
                .Setup(m => m.Send(command, default))
                .ReturnsAsync(mockResponse);

            // Act
            var result = await controller.RegisterProperty(command) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            
        }

        [Test]
        public async Task EditProperty_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            _configurationMock.Setup(config => config.GetSection("Configuration").GetSection("RouteServer").Value);
            var controller = new PropertyController(_mediatorMock.Object, _configurationMock.Object);
            
            var command = new UpdatePropertyCommand
            {
                IdProperty = 1,
                Name = "Property Prueba",
                Address = "Calle prueba",
                Price = 100000000,
                CodeInternal = "ABC123",
                YearProperty = 2023,
                IdOwner = 1
            };
            var mockResponse = new BaseResponse<bool>
            {
                IsSuccess = true,
                Data = true,
                Message = GlobalMessages.MESSAGE_UPDATE
            };

            _mediatorMock
                .Setup(m => m.Send(command, default))
                .ReturnsAsync(mockResponse);

            // Act
            var result = await controller.EditProperty(command) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task ChangePriceProperty_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            _configurationMock.Setup(config => config.GetSection("Configuration").GetSection("RouteServer").Value);
            var controller = new PropertyController(_mediatorMock.Object, _configurationMock.Object);
            var command = new ChangePricePropertyCommand
            {
                IdProperty = 1,
                Price = 50000000
            };
            var mockResponse = new BaseResponse<bool>
            {
                IsSuccess = true,
                Data = true,
                Message = GlobalMessages.MESSAGE_UPDATE_PRICE
            };


            _mediatorMock
                .Setup(m => m.Send(command, default))
                .ReturnsAsync(mockResponse);

            // Act
            var result = await controller.ChangePriceProperty(command) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task AddImageProperty_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            _configurationMock.Setup(config => config.GetSection("Configuration").GetSection("RouteServer").Value)
            .Returns("C:\\RutaImagenes\\Properties");
            var controller = new PropertyController(_mediatorMock.Object, _configurationMock.Object);
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(f => f.FileName).Returns("imagen.jpg");
            fileMock.Setup(f => f.Length).Returns(12345);
            var command = new UploadImagePropertyCommand
            {
                IdProperty = 1,
                FilePropertyImage = fileMock.Object,
                Enabled = true
            };
            var mockResponse = new BaseResponse<bool>
            {
                IsSuccess = true,
                Data = true,
                Message = GlobalMessages.MESSAGE_ADD_IMAGE
            };
            _mediatorMock
                .Setup(m => m.Send(command, default))
                .ReturnsAsync(mockResponse);
            // Act
            var result = await controller.AddImageProperty(command) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            // Add more assertions if needed based on the response content
        }

        [Test]
        public async Task ListPropertyWithFilters_ValidFilter_ReturnsOkResult()
        {
            _configurationMock.Setup(config => config.GetSection("Configuration").GetSection("RouteServer").Value);
            // Arrange
            var controller = new PropertyController(_mediatorMock.Object, _configurationMock.Object);
            var filterQuery = new GetPropertyFilterQuery
            {
                Filter = "2023"
            };

            _mediatorMock
                 .Setup(m => m.Send(filterQuery, default))
                 .ReturnsAsync(new BaseResponse<IEnumerable<GetListPropertyResponseDto>>
                 {
                     IsSuccess = true,
                     Data = new List<GetListPropertyResponseDto>
                    {
                        new GetListPropertyResponseDto
                        {
                            IdProperty = 1,
                            Name = "Ejemplo Propiedad",
                            Address = "Dirección de ejemplo",
                            Price = 100000,
                            CodeInternal = "ABC123",
                            YearProperty = 2023,
                            Owner = "Propietario Ejemplo"
                        },
                    },
                     Message = "Propiedades obtenidas exitosamente"
                 });
            // Act
            var result = await controller.ListPropertyWithFilters(filterQuery.Filter) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            // Add more assertions if needed based on the response content
        }
    }
}
