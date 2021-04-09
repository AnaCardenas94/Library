using Newtonsoft.Json;

namespace Library.Models
{
    public class AccessInfo
    {
        [JsonProperty("webReaderLink")]
        public string WebReaderLink { get; set; }
    }
}
