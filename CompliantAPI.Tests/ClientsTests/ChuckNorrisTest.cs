using CompliantAPI.DTOs;
using CompliantAPI.Utilities.Clients;
using CompliantAPI.Utilities.Reponses;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CompliantAPI.Tests.ClientsTests
{
    public class ChuckNorrisTest
    {
        #region GetAllJokeCategories
        [Fact]
        public async void GetAllJokeCategories_ErrorHttpResponse_ReturnsNoContent()
        {
            // Arrange
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
                BaseAddress = new Uri("https://api.chucknorris.io/"),
            };
            ChuckNorris chuckNorris = new(httpClient);

            // Act
            ApiBaseResponse actual = await chuckNorris.GetAllJokeCategories();

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<ApiNoContentResponse>(actual);
        }
        [Fact]
        public async void GetAllJokeCategories_OkHttpResponseAndValidDataType_ReturnsNoContent()
        {
            // Arrange
            List<string> result = new();
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync
                (
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JsonConvert.SerializeObject(result)),
                    }
                );
            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri("https://api.chucknorris.io/"),
            };
            ChuckNorris chuckNorris = new(httpClient);

            // Act
            ApiBaseResponse actual = await chuckNorris.GetAllJokeCategories();

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<ApiOkResponse<List<string>>>(actual);
        }
        [Fact]
        public async void GetAllJokeCategories_OkHttpResponseAndInValidDataType_ReturnsNoContent()
        {
            // Arrange
            string result = "";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync
                (
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JsonConvert.SerializeObject(result)),
                    }
                );
            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri("https://api.chucknorris.io/"),
            };
            ChuckNorris chuckNorris = new(httpClient);

            // Act
            //ApiBaseResponse actual = await chuckNorris.GetAllJokeCategories();

            // Assert
            await Assert.ThrowsAsync<System.Text.Json.JsonException>(() => chuckNorris.GetAllJokeCategories());
        }
        #endregion GetAllJokeCategories

        #region SearchChuckNorrisJokes
        [Fact]
        public async void SearchChuckNorrisJokes_ErrorHttpResponse_ReturnsNoContent()
        {
            // Arrange
            string query = "";
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
                BaseAddress = new Uri("https://api.chucknorris.io/"),
            };
            ChuckNorris chuckNorris = new(httpClient);

            // Act
            ApiBaseResponse actual = await chuckNorris.SearchChuckNorrisJokes(query);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<ApiNoContentResponse>(actual);
        }
        [Fact]
        public async void SearchChuckNorrisJokes_OkHttpResponseAndValidDataType_ReturnsNoContent()
        {
            // Arrange
            string query = "";
            dynamic result = "";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync
                (
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JsonConvert.SerializeObject(result)),
                    }
                );
            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri("https://api.chucknorris.io/"),
            };
            ChuckNorris chuckNorris = new(httpClient);

            // Act
            ApiBaseResponse actual = await chuckNorris.SearchChuckNorrisJokes(query);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<ApiOkResponse<dynamic>>(actual);
        }
        #endregion SearchChuckNorrisJokes
    }
}
