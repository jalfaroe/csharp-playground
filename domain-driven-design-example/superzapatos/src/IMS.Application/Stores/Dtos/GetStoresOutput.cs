using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IMS.Application.Stores.Dtos
{
    public class GetStoresOutput
    {
        [DataMember(Name = "stores")]
        [JsonProperty(PropertyName = "stores")]
        public IList<StoreDto> Stores { get; set; }

        [DataMember(Name = "success")]
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [DataMember(Name = "total_elements")]
        [JsonProperty(PropertyName = "total_elements")]
        public int TotalElements
        {
            get { return Stores != null ? Stores.Count : 0; }
            set { }
        }
    }
}