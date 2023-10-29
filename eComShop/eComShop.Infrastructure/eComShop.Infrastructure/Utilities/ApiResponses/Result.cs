

namespace eComShop.Infrastructure.Utilities.ApiResponses
{
    public class Result<T> where T : class
    {

        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; }
    }
}