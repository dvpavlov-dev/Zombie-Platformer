using System;

namespace Zombie_Platformer.Infrastructure
{
    public class GameProcess : IGameProcess
    {
        public Action OnGameOver { get; set; }

        private bool _isGameOver;

        public bool IsGameOver
        {
            get => _isGameOver;
            set
            {
                if (value)
                {
                    OnGameOver?.Invoke();
                }

                _isGameOver = value;
            }
        }
    }
}