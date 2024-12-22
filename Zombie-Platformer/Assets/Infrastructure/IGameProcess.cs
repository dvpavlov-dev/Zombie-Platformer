using System;

namespace Zombie_Platformer.Infrastructure
{
    public interface IGameProcess
    {
        public Action OnGameOver { get; set; }
        public bool IsGameOver { get; set; }
    }
}