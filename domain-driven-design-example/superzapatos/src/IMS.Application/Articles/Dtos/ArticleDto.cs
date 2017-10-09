using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IMS.Application.Stores.Dtos;
using Newtonsoft.Json;

namespace IMS.Application.Articles.Dtos
{
    [DataContract(Name = "article")]
    [JsonObject(Title = "article")]
    public class ArticleDto
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

        [DataMember(Name = "description")]
        [JsonProperty(PropertyName = "description")]
        [StringLength(150)]
        public string Description { get; set; }

        [DataMember(Name = "price")]
        [JsonProperty(PropertyName = "price")]
        [Required]
        public decimal Price { get; set; }

        [DataMember(Name = "total_in_shelf")]
        [JsonProperty(PropertyName = "total_in_shelf")]
        [Required]
        [Display(Name = "Total In Shelf")]
        [Range(0, int.MaxValue)]
        public decimal TotalInShelf { get; set; }

        [DataMember(Name = "total_in_vault")]
        [JsonProperty(PropertyName = "total_in_vault")]
        [Required]
        [Display(Name = "Total In Vault")]
        [Range(0, int.MaxValue)]
        public decimal TotalInVault { get; set; }

        [IgnoreDataMember]
        [Required]
        [Display(Name = "Store")]
        public int StoreId { get; set; }

        [DataMember(Name = "store_name")]
        [JsonProperty(PropertyName = "store_name")]
        public string StoreName
        {
            get { return Store.Name; }
            set { }
        }

        [IgnoreDataMember]
        public virtual StoreDto Store { get; set; }
    }
}