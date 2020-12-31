using NHL.Data.Interfaces;
using System.Collections.Generic;

namespace NHL_Core.Client.Models
{
    public class RequestResponse<TResult>
        where TResult : INHLModel
    {
        private RequestResponse(
            bool success,
            List<TResult> data,
            List<string> errors)
        {
            Success = success;
            Data = data ?? new List<TResult>();
            Errors = errors ?? new List<string>();
        }

        public bool Success { get; }
        public List<TResult> Data { get; }
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