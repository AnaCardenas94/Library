using Newtonsoft.Json;

namespace Library.Models
{
    public class GoogleApiResponse
    {
        
            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("totalItems")]
            public int TotalItems { get; set; }

            [JsonProperty("items")]
            public Item[] Items { get; set; }         
    }
}
