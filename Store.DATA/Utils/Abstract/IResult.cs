using Store.DATA.Utils.ComplexTypes;

namespace Store.DATA.Utils.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
    }
}
