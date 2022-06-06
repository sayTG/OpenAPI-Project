﻿namespace CompliantAPI.Utilities.Reponses
{
    public abstract class ApiNoContentResponse : ApiBaseResponse
    {
        public string Message { get; set; }
        public ApiNoContentResponse(string message) : base(false)
        {
            Message = message;
        }
    }
}
