using NHL.Data.Model;
using System.Collections.Generic;

namespace NHL.Client.ResponseModels
{
    internal class ConferenceResponseModel
    {
        public List<Conference> Conferences { get; set; }
        public string Copyright { get; set; }
    }
}
