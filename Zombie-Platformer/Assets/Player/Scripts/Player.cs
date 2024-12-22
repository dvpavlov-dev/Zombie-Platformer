using UnityEngine;
using Zenject;
using Zombie_Platformer.Infrastructure;

namespace Zombie_Platformer.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _deadSound;

        private IGameProcess _gameProcess;

        private const string ENEMY_TAG = "Enemy";

        [Inject]
        private void Constructor(IGameProcess gameProcess)
        {
            _gameProcess = gameProcess;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(ENEMY_TAG))
            {
                _audioSource.clip = _deadSound;
                _audioSource.Play();

                _gameProcess.IsGameOver = true;
            }
        }
    }
}