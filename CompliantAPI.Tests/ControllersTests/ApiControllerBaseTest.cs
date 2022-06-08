using CompliantAPI.Controllers;
using CompliantAPI.Utilities.Reponses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompliantAPI.Tests.ControllersTests
{
    public class ApiControllerBaseTest
    {
        [Fact]
        public void ProcessError_NoContentResponse_ReturnsNoContent()
        {
            // Arrange
            ApiBaseResponse baseResponse = new ApiNoContentResponse("");
            ApiControllerBase _controller = new();

            // Act
            IActionResult actual = _controller.ProcessError(baseResponse);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<NoContentResult>(actual);
        }
        [Fact]
        public void ProcessError_BadRequestResponse_ReturnsNoContent()
        {
            // Arrange
            ApiBaseResponse baseResponse = new ApiBadRequestResponse("");
            ApiControllerBase _controller = new();

            // Act
            IActionResult actual = _controller.ProcessError(baseResponse);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<BadRequestObjectResult>(actual);
        }
    }
}
