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
        public IDictionary<string, string> Info { get; set; }

        [JsonProperty("packages")]
        public IList<Package> Packages { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <example>
    /// Microsoft.VisualStudio.Debugger.Concord.Remote.Resources
    ///     ,version=17.0.31512.284
    ///     ,chip=x64
    ///     ,language=zh-CN
    ///     ,productarch=neutral
    ///     ,machinearch=ARM64
    /// 
    /// Microsoft.VisualStudio.Branding.Enterprise
    ///     ,version=17.0.31512.422
    ///     ,language=zh-CN
    ///     ,branch=preview
    ///     ,productarch=x64
    /// </example>
    public partial class Package
    {
        [JsonProperty("type")]
        public string Type { get; set; }


        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("chip")]
        public string Chip { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("branch")]
        public string Branch { get; set; }

        [JsonProperty("productarch")]
        public string Productarch { get; set; }

        [JsonProperty("machinearch")]
        public string Machinearch { get; set; }

    }
}
