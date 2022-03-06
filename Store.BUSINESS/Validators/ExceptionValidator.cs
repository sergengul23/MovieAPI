using Microsoft.AspNetCore.Http;

namespace Store.BUSINESS.Validators
{
    public class ExceptionValidator : Exception
    {
        private bool IsSuccess { get; set; }
        private int StatusCode { get; set; }
        public List<string> Errors { get; set; }

        public ExceptionValidator(List<string> errors)
        {
            IsSuccess = false;
            StatusCode = StatusCodes.Status400BadRequest;
            Errors = errors;
        }
    }
}
