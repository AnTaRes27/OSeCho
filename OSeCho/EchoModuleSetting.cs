using antares27.osecho.UI;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.ObjectModel;
using VRCOSC.App.SDK.Modules.Attributes.Settings;
using VRCOSC.App.SDK.Parameters.Queryable;
using VRCOSC.App.Utils;

namespace antares27.osecho
{
    public class EchoModuleSetting : ListModuleSetting<EchoParam>
    {
        public EchoModuleSetting() : base("Echo Params", "Add, edit, and remove parameters", typeof(EchoParamsSettingView), [])
        {
        }

        protected override EchoParam CreateItem() => new();
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class EchoParam : IEquatable<EchoParam>
    {
        [JsonProperty("id")]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty("name")]
        public Observable<string> Name { get; set; } = new("New Echoed Parameter Pair");

        [JsonProperty("input_parameter")]
        public Observable<string> InputParameter { get; set; } = new(string.Empty);

        [JsonProperty("output_parameter")]
        public Observable<string> OutputParameter { get; set; } = new(string.Empty);

        //[JsonProperty("echoparams")]
        //public ObservableCollection<Observable<EchoParam>> EchoParams { get; set; } = [];

        [JsonConstructor]
        public EchoParam()
        {
        }

        public bool Equals(EchoParam? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Name.Equals(other.Name);
        }
    }
}
