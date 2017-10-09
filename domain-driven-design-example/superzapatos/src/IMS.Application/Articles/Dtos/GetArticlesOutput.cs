using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IMS.Application.Articles.Dtos
{
    public class GetArticlesOutput
    {
        [DataMember(Name = "articles")]
        [JsonProperty(PropertyName = "articles")]
        public IList<ArticleDto> Articles { get; set; }

        [DataMember(Name = "success")]
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [DataMember(Name = "total_elements")]
        [JsonProperty(PropertyName = "total_elements")]
        public int TotalElements
        {
            get { return Articles != null ? Articles.Count : 0; }
            set { }
        }
    }
}