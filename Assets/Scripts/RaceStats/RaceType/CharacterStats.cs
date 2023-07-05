using System;

namespace RaceStats.RaceType
{
    public class CharacterStats
    {
        private RaceType _race;

        public CharacterStats(Player player, RaceType raceType)
        {
            _race = raceType;
            Stats stats = GetStats();
            player.GetStats(stats);
        }

        private Stats GetStats()
        {
            switch (_race)
            {
                case RaceType.Wars:
                    return new Stats()
                    {
                        Damage = 10,
                        Health = 100,
                        AttackSpead = 0.3f,
                        Spead = 5f,
                    };
                case RaceType.Knight:
                    return new Stats()
                    {
                        Damage = 20,
                        Health = 120,
                        AttackSpead = 0.3f,
                        Spead = 4f,
                    };
                default:
                    return new Stats()
                    {
                        Damage = 10,
                        Health = 100,
                        AttackSpead = 0.3f,
                        Spead = 5f,
                    };
            }
        }
    }
}