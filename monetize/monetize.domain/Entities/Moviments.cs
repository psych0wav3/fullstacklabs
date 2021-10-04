using monetize.domain.enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace monetize.domain.entities
{
    public class Moviments : Entity
    {
        public double Value { get; set; }
        public MovimentEnum Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Currency OldCurrency { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Currency NewCurrency { get; set; }
    }
}