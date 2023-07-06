namespace Averus.Dota2.DataScraper.OpenDotaApi.Models
{
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HeroRole
    {
        Carry,
        Disabler,
        Durable,
        Escape,
        Initiator,
        Jungler,
        Nuker,
        Pusher,
        Support
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HeroPrimaryAttribute
    {
        Agi,
        Int,
        Str,
        All,
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HeroAttackType
    {
        Melee,
        Ranged
    }
}
