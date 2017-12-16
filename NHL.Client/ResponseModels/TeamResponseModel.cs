using NHL.Data.Model;
using System.Collections.Generic;

namespace NHL.Client.ResponseModels
{
    internal class TeamResponseModel
    {
        public List<Team> Teams { get; set; }
        public string Copyright { get; set; }
    }
}
