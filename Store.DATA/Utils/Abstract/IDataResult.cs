namespace Store.DATA.Utils.Abstract
{
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; }
    }
}
