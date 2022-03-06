using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;

namespace Store.DATA.Utils.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }

        public Result(ResultStatus resultStatus, string message)
        {
            ResultStatus = resultStatus;
            Message = message;
        }

        public ResultStatus ResultStatus { get; }
        public string Message { get; }
    }
}
