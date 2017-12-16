using NHL.Data.Model;
using System.Collections.Generic;

namespace NHL.Client.ResponseModels
{
    internal class FranchiseResponseModel
    {
        public List<Franchise> Franchises { get; set; }
        public string Copyright { get; set; }
    }
}
