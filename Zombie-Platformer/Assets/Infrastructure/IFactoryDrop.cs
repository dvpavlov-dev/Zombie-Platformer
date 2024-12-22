using UnityEngine;

namespace Zombie_Platformer.Infrastructure
{
    public interface IFactoryDrop
    {
        public GameObject CreateDropAmmo(Vector3 spawnPos, int amountAmmo);
    }
}
