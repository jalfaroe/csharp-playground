using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IMS.Application.Stores.Dtos
{
    [DataContract(Name = "store")]
    [JsonObject(Title = "store")]
    public class StoreDto
    {
        [DataMember(Name = "id")]
        [JsonProperty(PropertyName = "id")]
        [Required]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        [JsonProperty(PropertyName = "name")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [DataMember(Name = "address")]
        [JsonProperty(PropertyName = "address")]
        [StringLength(100)]
        public string Address { get; set; }
    }
}