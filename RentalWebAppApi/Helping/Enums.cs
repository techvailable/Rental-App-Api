
using System.Text.Json.Serialization;

namespace RentalWebAppApi.Helping
{
    public class Enums
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public  enum ProductTypes
        {
            Featured,
            Hot
        }
    }
}
