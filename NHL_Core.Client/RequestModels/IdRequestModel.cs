using NHL.Data.Interfaces;

namespace NHL_Core.Client.RequestModels
{
    public class IdRequestModel<TResult> : RequestModelBase<TResult>
         where TResult : INHLModel, new()
    {
        public int Id { get; set; }

        public override string GetRequestQueryParameters()
        {
            if (Id == 0)
            {
                return string.Empty;
            }

            return Id.ToString();
        }
    }
}