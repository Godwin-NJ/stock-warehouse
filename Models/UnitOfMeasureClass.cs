using System.Text.Json.Serialization;

namespace stock_to_inventoryy.Models
{
   // [JsonConverter(typeof(JsonStringEnumConverter))] //this attribute helps present the key-value (Knight)
    public enum UnitOfMeasure
    {
        CTN , //carton
        BTL  //Bottle
    }
}
