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
    public class SearchControllerTest
    {
        private readonly Mock<IDataService> _dataServiceMock;
        public SearchControllerTest()
        {
            _dataServiceMock = new Mock<IDataService>(MockBehavior.Default);
        }
        [Fact]
        public async void Search_NoContentResponse_ReturnsNoContent()
        {
            // Arrange
            string query = "";
            int page = 1;
            _dataServiceMock.Setup(d => d.SearchChuckNorris_Swapi(query, page)).ReturnsAsync(new ApiNoContentResponse(""));
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
        public async void Search_BadRequestResponse_ReturnsBadRequest()
        {
            // Arrange
            string query = "";
            int page = 1;
            _dataServiceMock.Setup(d => d.SearchChuckNorris_Swapi(query, page)).ReturnsAsync(new ApiBadRequestResponse(""));
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
        public async void Search_OkResponseAndInValidReturnType_ReturnsOk()
        {
            // Arrange
            string query = "";
            string value = "car";
            int page = 1;
            _dataServiceMock.Setup(d => d.SearchChuckNorris_Swapi(query, page)).ReturnsAsync(new ApiOkResponse<string>(value));
            SearchController _controller = new(_dataServiceMock.Object);

            // Act
            //IActionResult actual = await _controller.Search();

            // Assert
            await Assert.ThrowsAsync<InvalidCastException>(() => _controller.Search(query));
        }

        [Fact]
        public async void Search_OkResponseAndValidReturnType_ReturnsOk()
        {
            // Arrange
            string query = "";
            int page = 1;
            ChuckNorris_SwapDTO value = new();
            _dataServiceMock.Setup(d => d.SearchChuckNorris_Swapi(query, page)).ReturnsAsync(new ApiOkResponse<ChuckNorris_SwapDTO>(value));
            SearchController _controller = new(_dataServiceMock.Object);

            // Act
            IActionResult actual = await _controller.Search(query);
            OkObjectResult actualStatusCode = (OkObjectResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual);
            Assert.IsType<ChuckNorris_SwapDTO>(actualStatusCode.Value);
            Assert.Equal(200, actualStatusCode.StatusCode);
        }
    }
}