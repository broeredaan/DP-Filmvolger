using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Filmvolger.Classes
{
    class Rating
    {
        private string source;
        private string value;

        public Rating(JToken rating)
        {
            Source = (string) rating["Source"];
            Value = (string) rating["Value"];
        }

        public string Value { get => value; set => this.value = value; }
        public string Source { get => source; set => source = value; }
    }
}
