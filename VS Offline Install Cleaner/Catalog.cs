using System.Collections.Generic;
using Newtonsoft.Json;

namespace VS_Offline_Install_Cleaner
{
    public class Catalog
    {
        [JsonProperty("manifestVersion")]
        public string ManifestVersion { get; set; }

        [JsonProperty("engineVersion")]
        public string EngineVersion { get; set; }

        [JsonProperty("info")]
        public Dictionary<string, string> Info { get; set; }

        [JsonProperty("packages")]
        public List<Package> Packages { get; set; }
    }


    public partial class Package
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("chip")]
        public string Chip { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

    }
}
