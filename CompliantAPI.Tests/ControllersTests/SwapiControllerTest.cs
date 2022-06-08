using CompliantAPI.Abstractions.IServices;
using CompliantAPI.Controllers;
using CompliantAPI.DTOs;
using CompliantAPI.Utilities.Reponses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompliantAPI.Tests.ControllersTests
{
    public class SwapiControllerTest
    {
        private readonly Mock<IDataService> _dataServiceMock;
        public SwapiControllerTest()
        {
            _dataServiceMock = new Mock<IDataService>(MockBehavior.Default);
        }
        [Fact]
        public async void People_ApiNoContentResponse_ReturnsNoContent()
        {
            // Arrange
            int pages = 1;
            _dataServiceMock.Setup(d => d.AllStarWarsPeople(pages)).ReturnsAsync(new ApiNoContentResponse(""));
            SwapiController _controller = new(_dataServiceMock.Object);

            // Act
            IActionResult actual = await _controller.People(pages);
            NoContentResult actualStatusCode = (NoContentResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<NoContentResult>(actual);
            Assert.Equal(204, actualStatusCode.StatusCode);
        }
        [Fact]
        public async void People_ApiBadRequestResponse_ReturnsBadRequest()
        {
            // Arrange
            int pages = 1;
            _dataServiceMock.Setup(d => d.AllStarWarsPeople(pages)).ReturnsAsync(new ApiBadRequestResponse(""));
            SwapiController _controller = new(_dataServiceMock.Object);

            // Act
            IActionResult actual = await _controller.People(pages);
            BadRequestObjectResult actualStatusCode = (BadRequestObjectResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<BadRequestObjectResult>(actual);
            Assert.Equal(400, actualStatusCode.StatusCode);
        }
        [Fact]
        public async void People_ApiOkResponseAndInValidReturnType_ReturnsOk()
        {
            // Arrange
            int pages = 1;
            string value = "car";
            _dataServiceMock.Setup(d => d.AllStarWarsPeople(pages)).ReturnsAsync(new ApiOkResponse<string>(value));
            SwapiController _controller = new(_dataServiceMock.Object);

            // Act
            //IActionResult actual = await _controller.People();

            // Assert
            await Assert.ThrowsAsync<InvalidCastException>(() => _controller.People(pages));
        }

        [Fact]
        public async void People_ApiOkResponseAndValidReturnType_ReturnsOk()
        {
            // Arrange
            int pages = 1;
            SwapiDTO value = new();
            _dataServiceMock.Setup(d => d.AllStarWarsPeople(pages)).ReturnsAsync(new ApiOkResponse<SwapiDTO>(value));
            SwapiController _controller = new(_dataServiceMock.Object);

            // Act
            IActionResult actual = await _controller.People(pages);
            OkObjectResult actualStatusCode = (OkObjectResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual);
            Assert.IsType<SwapiDTO>(actualStatusCode.Value);
            Assert.Equal(200, actualStatusCode.StatusCode);
        }
    }
}
