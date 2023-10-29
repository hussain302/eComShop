using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eComShop.Domain.Primitives
{
    public class Result<T>
    {
        public T Value { get; private set; }
        public bool IsSuccess { get; private set; }
        public string ErrorMessage { get; private set; }

        private Result(T value)
        {
            Value = value;
            IsSuccess = true;
        }

        private Result(string errorMessage)
        {
            ErrorMessage = errorMessage;
            IsSuccess = false;
        }

        public static Result<T> Success(T value) => new Result<T>(value);
        public static Result<T> Failure(string errorMessage) => new Result<T>(errorMessage);
    }

}
