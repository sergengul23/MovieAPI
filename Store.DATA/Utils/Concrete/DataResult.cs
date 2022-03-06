﻿using Store.DATA.Utils.Abstract;
using Store.DATA.Utils.ComplexTypes;

namespace Store.DATA.Utils.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(ResultStatus resultStatus, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }

        public DataResult(ResultStatus resultStatus, string message, T data)
        {
            ResultStatus = resultStatus;
            Message = message;
            Data = data;
        }

        public T Data { get; }
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
    }
}
