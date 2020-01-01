using NHL.Data.Interfaces;
using System.Collections.Generic;

namespace NHL_Core.Client.Models
{
    public class RequestResponse<TResult>
        where TResult : INHLModel
    {
        private RequestResponse(
            bool isSuccess,
            List<TResult> results,
            List<string> errors)
        {
            IsSuccess = isSuccess;
            Results = results ?? new List<TResult>();
            Errors = errors ?? new List<string>();
        }

        public bool IsSuccess { get; }
        public List<TResult> Results { get; }
        public List<string> Errors { get; }

        internal static RequestResponse<TResult> Fail(List<string> errors)
        {
            return new RequestResponse<TResult>(false, null, errors);
        }

        internal static RequestResponse<TResult> Fail(string error)
        {
            return new RequestResponse<TResult>(false, null, new List<string> { error });
        }

        internal static RequestResponse<TResult> Ok(List<TResult> results)
        {
            return new RequestResponse<TResult>(true, results, null);
        }
    }
}