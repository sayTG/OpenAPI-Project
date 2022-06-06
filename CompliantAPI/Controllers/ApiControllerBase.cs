using CompliantAPI.ErrorModel;
using CompliantAPI.Utilities.Reponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompliantAPI.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        public IActionResult ProcessError(ApiBaseResponse baseResponse)
        {
            return baseResponse switch
            {
                ApiNoContentResponse => NoContent(),

                ApiBadRequestResponse => BadRequest(new ErrorDetails
                {
                    Message = ((ApiBadRequestResponse)baseResponse).Message,
                    StatusCode = StatusCodes.Status400BadRequest
                }),
                _ => throw new NotImplementedException()
            };
        }
    }
}
