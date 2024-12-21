using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
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
            _gameProcess.IsGameOver = true;
        }
    }
}
