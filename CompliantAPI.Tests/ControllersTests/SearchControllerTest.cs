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
    public class SearchControllerTest
    {
        private readonly Mock<IDataService> _dataServiceMock;
        public SearchControllerTest()
        {
            _dataServiceMock = new Mock<IDataService>(MockBehavior.Default);
        }
        [Fact]
        public async void Search_ApiNoContentResponse_ReturnsNoContent()
        {
            // Arrange
            string query = "";
            _dataServiceMock.Setup(d => d.SearchChuckNorris_Swapi(query)).ReturnsAsync(new ApiNoContentResponse(""));
            SearchController _controller = new(_dataServiceMock.Object);

            // Act
            IActionResult actual = await _controller.Search(query);
            NoContentResult actualStatusCode = (NoContentResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<NoContentResult>(actual);
            Assert.Equal(204, actualStatusCode.StatusCode);
        }
        [Fact]
        public async void Search_ApiBadRequestResponse_ReturnsBadRequest()
        {
            // Arrange
            string query = "";
            _dataServiceMock.Setup(d => d.SearchChuckNorris_Swapi(query)).ReturnsAsync(new ApiBadRequestResponse(""));
            SearchController _controller = new(_dataServiceMock.Object);

            // Act
            IActionResult actual = await _controller.Search(query);
            BadRequestObjectResult actualStatusCode = (BadRequestObjectResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<BadRequestObjectResult>(actual);
            Assert.Equal(400, actualStatusCode.StatusCode);
        }
        [Fact]
        public async void Search_ApiOkResponseAndInValidReturnType_ReturnsOk()
        {
            // Arrange
            string query = "";
            string value = "car";
            _dataServiceMock.Setup(d => d.SearchChuckNorris_Swapi(query)).ReturnsAsync(new ApiOkResponse<string>(value));
            SearchController _controller = new(_dataServiceMock.Object);

            // Act
            //IActionResult actual = await _controller.Search();

            // Assert
            await Assert.ThrowsAsync<InvalidCastException>(() => _controller.Search(query));
        }

        [Fact]
        public async void Search_ApiOkResponseAndValidReturnType_ReturnsOk()
        {
            // Arrange
            string query = "";
            List<string> value = new() { "car", "vehicle" };
            _dataServiceMock.Setup(d => d.SearchChuckNorris_Swapi(query)).ReturnsAsync(new ApiOkResponse<List<string>>(value));
            SearchController _controller = new(_dataServiceMock.Object);

            // Act
            IActionResult actual = await _controller.Search(query);
            OkObjectResult actualStatusCode = (OkObjectResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual);
            Assert.Equal(200, actualStatusCode.StatusCode);
        }
    }
}