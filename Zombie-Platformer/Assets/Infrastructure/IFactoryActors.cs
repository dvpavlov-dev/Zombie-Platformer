using UnityEngine;

namespace Zombie_Platformer.Infrastructure
{
    public interface IFactoryActors
    {
        public GameObject CreatePlayer();
    }
}