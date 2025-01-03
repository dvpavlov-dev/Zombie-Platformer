using UnityEngine;

namespace Zombie_Platformer.Infrastructure
{
    public class Configs : MonoBehaviour
    {
        [Header("Player configs")]
        public PlayerConfigSource PlayerConfig;
        public WeaponConfigSource WeaponConfig;

        [Header("Enemy configs")]
        public BaseEnemyConfigSource BaseEnemyConfig;
        public AdvanceEnemyConfigSource AdvanceEnemyConfig;
        public EliteEnemyConfigSource EliteEnemyConfig;
        public TankEnemyConfigSource TankEnemyConfig;
        public FastEnemyConfigSource FastEnemyConfig;
    }
}