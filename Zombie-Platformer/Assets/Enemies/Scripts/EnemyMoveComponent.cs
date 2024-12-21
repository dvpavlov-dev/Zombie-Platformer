using UnityEngine;
using Zenject;

public class EnemyMoveComponent : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private float _speed;
    private IGameProcess _gameProcess;

    [Inject]
    private void Constructor(Configs configs, IGameProcess gameProcess)
    {
        _gameProcess = gameProcess;
    }

    public void Init(Vector3 targetPos, EnemyConfigSource enemyConfig)
    {
        _speed = enemyConfig.Speed;

        if (targetPos.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    
    void FixedUpdate()
    {
        if (_gameProcess.IsGameOver)
        {
            _animator.enabled = false;
            return;
        }
        
        transform.Translate(_speed * Time.deltaTime, 0, 0);
    }
}
