using CompliantAPI.Utilities.Reponses;

namespace CompliantAPI.Utilities.Extensions
{
    public static class ApiBaseResponseExtensions
    {
        public static TResultType GetResult<TResultType>(this ApiBaseResponse apiBaseResponse)
            =>
                ((ApiOkResponse<TResultType>)apiBaseResponse).Result;
    }
}
