using CompliantAPI.DTOs;
using CompliantAPI.Utilities.Clients;
using CompliantAPI.Utilities.Reponses;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;

namespace CompliantAPI.Tests.ClientsTests
{
    public class SwapiTest
    {
        #region AllStarWarsPeople
        [Fact]
        public async void AllStarWarsPeople_ErrorHttpResponse_ReturnsNoContent()
        {
            // Arrange
            int page = 1;
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync
                (
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Content = new StringContent("")
                    }
                );
            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri("https://swapi.dev/api/"),
            };
            Swapi swapi = new(httpClient);

            // Act
            ApiBaseResponse actual = await swapi.AllStarWarsPeople(page);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<ApiNoContentResponse>(actual);
        }
        [Fact]
        public async void AllStarWarsPeople_OkHttpResponseAndValidDataType_ReturnsNoContent()
        {
            // Arrange
            SwapiDTO swapiDTO = new SwapiDTO();
            int page = 1;
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync
                (
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JsonConvert.SerializeObject(swapiDTO)),
                    }
                );
            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri("https://swapi.dev/api/"),
            };
            Swapi swapi = new(httpClient);

            // Act
            ApiBaseResponse actual = await swapi.AllStarWarsPeople(page);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<ApiOkResponse<SwapiDTO>>(actual);
        }
        [Fact]
        public async void AllStarWarsPeople_OkHttpResponseAndInValidDataType_ReturnsNoContent()
        {
            // Arrange
            string swapiDTO = "";
            int page = 1;
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync
                (
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JsonConvert.SerializeObject(swapiDTO)),
                    }
                );
            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri("https://swapi.dev/api/"),
            };
            Swapi swapi = new(httpClient);

            // Act
            //ApiBaseResponse actual = await swapi.AllStarWarsPeople(page);

            // Assert
            await Assert.ThrowsAsync<System.Text.Json.JsonException>(() => swapi.AllStarWarsPeople(page));
        }
        #endregion AllStarWarsPeople

        #region SearchStarWarsPeople
        [Fact]
        public async void SearchStarWarsPeople_ErrorHttpResponse_ReturnsNoContent()
        {
            // Arrange
            string query = "";
            int page = 1;
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync
                (
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Content = new StringContent("")
                    }
                );
            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri("https://swapi.dev/api/"),
            };
            Swapi swapi = new(httpClient);

            // Act
            ApiBaseResponse actual = await swapi.SearchStarWarsPeople(query, page);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<ApiNoContentResponse>(actual);
        }
        [Fact]
        public async void SearchStarWarsPeople_OkHttpResponseAndValidDataType_ReturnsNoContent()
        {
            // Arrange
            SwapiDTO swapiDTO = new SwapiDTO();
            string query = "";
            int page = 1;
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync
                (
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JsonConvert.SerializeObject(swapiDTO)),
                    }
                );
            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri("https://swapi.dev/api/"),
            };
            Swapi swapi = new(httpClient);

            // Act
            ApiBaseResponse actual = await swapi.SearchStarWarsPeople(query, page);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<ApiOkResponse<SwapiDTO>>(actual);
        }
        [Fact]
        public async void SearchStarWarsPeople_OkHttpResponseAndInValidDataType_ReturnsNoContent()
        {
            // Arrange
            string swapiDTO = "";
            string query = "";
            int page = 1;
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync
                (
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JsonConvert.SerializeObject(swapiDTO)),
                    }
                );
            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri("https://swapi.dev/api/"),
            };
            Swapi swapi = new(httpClient);

            // Act
            //ApiBaseResponse actual = await swapi.AllStarWarsPeople(page);

            // Assert
            await Assert.ThrowsAsync<System.Text.Json.JsonException>(() => swapi.SearchStarWarsPeople(query,page));
        }
        #endregion SearchStarWarsPeople
    }
}
