namespace Averus.Dota2.DataScraper.OpenDotaApi.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Hero
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("localized_name")]
        public string LocalizedName { get; set; }

        [JsonProperty("primary_attr")]
        public HeroPrimaryAttribute? PrimaryAttr { get; set; }

        [JsonProperty("attack_type")]
        public HeroAttackType? AttackType { get; set; }

        [JsonProperty("roles")]
        public List<HeroRole> Roles { get; set; }

        [JsonProperty("legs")]
        public long? Legs { get; set; }
    }
}
