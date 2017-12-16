using NHL.Data.Model;
using System.Collections.Generic;

namespace NHL.Client.ResponseModels
{
    internal class DivisionsResponseModel
    {
        public List<Division> Divisions { get; set; }
        public string Copyright { get; set; }
    }
}
