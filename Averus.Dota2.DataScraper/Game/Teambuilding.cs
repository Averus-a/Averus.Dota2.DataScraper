namespace Averus.Dota2.DataScraper.Game
{
    using Averus.Dota2.DataScraper.OpenDotaApi.Models;

    internal static class Teambuilding
    {
        // Safe lane = 1 | 5 | 4
        // Off lane  = 3 | 4
        // Mid lane  = 2

        public static int[] GetTeamPosition(List<HeroRole> heroRoles)
        {
            var positions = new List<int>();

            foreach(var role in heroRoles)
            {
                switch (role)
                {
                    case HeroRole.Carry:
                        positions.Add(1);
                        break;
                    case HeroRole.Disabler:
                        positions.Add(2);
                        positions.Add(3);
                        positions.Add(4);
                        positions.Add(5);
                        break;
                    case HeroRole.Durable: // Consider this as a "Core". Cannot perform well on 5th pos, need items to maintain damage
                        positions.Add(1);
                        positions.Add(3);
                        positions.Add(4);
                        break;
                    case HeroRole.Escape: // No impact on position
                        break;
                    case HeroRole.Initiator:
                        positions.Add(2);
                        positions.Add(3);
                        positions.Add(4);
                        positions.Add(5);
                        break;
                    case HeroRole.Jungler:
                        positions.Add(4);
                        break;
                    case HeroRole.Nuker:
                        positions.Add(2);
                        positions.Add(3);
                        positions.Add(4);
                        positions.Add(5);
                        break;
                    case HeroRole.Pusher: // No impact on position, it's a set of very different characters.
                        break;
                    case HeroRole.Support: // Carry babysitting, thus always 5th pos
                        positions.Add(5);
                        break;
                }
            }
            return positions.Distinct().ToArray();
        }
    }
}
