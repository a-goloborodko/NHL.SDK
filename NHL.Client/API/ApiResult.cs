using System.Net;

namespace NHL.Client.API
{
    public class ApiResult<T>
    {
        public bool IsSuccess { get { return HttpStatusResult == (int)HttpStatusCode.OK; } }
        public int HttpStatusResult { get; }
        public T Result { get; }

        public ApiResult(int httpStatusCode, T result)
        {
            HttpStatusResult = httpStatusCode;
            Result = result;
        }
    }
}