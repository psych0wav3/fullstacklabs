using monetize.domain.enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace monetize.domain.entities
{
    public class Balance : Entity
    {
        public Balance(double value, Currency currency){
            Value = value;
            Currency = currency;
        }
        public Balance(){}

        public double Value { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Currency Currency { get; set; }

        public void UpdateValue(double value){
            Value = value;
        }
    }
}