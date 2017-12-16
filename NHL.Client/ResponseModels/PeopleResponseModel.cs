using NHL.Data.Model;
using System.Collections.Generic;

namespace NHL.Client.ResponseModels
{
    internal class PeopleResponseModel
    {
        public List<Player> People { get; set; }
        public string Copyright { get; set; }
    }
}
