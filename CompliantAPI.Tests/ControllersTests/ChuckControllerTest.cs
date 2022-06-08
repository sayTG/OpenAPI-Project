using CompliantAPI.Abstractions.IServices;
using CompliantAPI.Controllers;
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
    public class ChuckControllerTest
    {
        private readonly Mock<IDataService> _dataServiceMock;
        public ChuckControllerTest()
        {
            _dataServiceMock = new Mock<IDataService>(MockBehavior.Default);
        }
        [Fact]
        public async void Categories_NoContentResponse_ReturnsNoContent()
        {
            // Arrange
            _dataServiceMock.Setup(d => d.AllJokeCategories()).ReturnsAsync(new ApiNoContentResponse(""));
            ChuckController _controller = new(_dataServiceMock.Object);

            // Act
            IActionResult actual = await _controller.Categories();
            NoContentResult actualStatusCode = (NoContentResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<NoContentResult>(actual);
            Assert.Equal(204, actualStatusCode.StatusCode);
        }
        [Fact]
        public async void Categories_BadRequestResponse_ReturnsBadRequest()
        {
            // Arrange
            _dataServiceMock.Setup(d => d.AllJokeCategories()).ReturnsAsync(new ApiBadRequestResponse(""));
            ChuckController _controller = new(_dataServiceMock.Object);

            // Act
            IActionResult actual = await _controller.Categories();
            BadRequestObjectResult actualStatusCode = (BadRequestObjectResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<BadRequestObjectResult>(actual);
            Assert.Equal(400, actualStatusCode.StatusCode);
        }
        [Fact]
        public async void Categories_OkResponseAndInValidReturnType_ReturnsOk()
        {
            // Arrange
            string value = "car";
            _dataServiceMock.Setup(d => d.AllJokeCategories()).ReturnsAsync(new ApiOkResponse<string>(value));
            ChuckController _controller = new(_dataServiceMock.Object);

            // Act
            //IActionResult actual = await _controller.Categories();

            // Assert
            await Assert.ThrowsAsync<InvalidCastException>(() => _controller.Categories());
        }

        [Fact]
        public async void Categories_OkResponseAndValidReturnType_ReturnsOk()
        {
            // Arrange
            List<string> value = new() { "car", "vehicle" };
            _dataServiceMock.Setup(d => d.AllJokeCategories()).ReturnsAsync(new ApiOkResponse<List<string>>(value));
            ChuckController _controller = new(_dataServiceMock.Object);

            // Act
            IActionResult actual = await _controller.Categories();
            OkObjectResult actualStatusCode = (OkObjectResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual);
            Assert.IsType<List<string>>(actualStatusCode.Value);
            Assert.Equal(200, actualStatusCode.StatusCode);
        }
    }
}
