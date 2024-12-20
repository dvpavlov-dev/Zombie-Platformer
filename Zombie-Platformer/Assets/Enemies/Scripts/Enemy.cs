using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private DamageController _damageController;
    [SerializeField] private GameObject _zombieDeadEffectPrefab;
    
    private IFactoryDrop _factoryDrop;

    [Inject]
    private void Constructor(IFactoryDrop factoryDrop)
    {
        _factoryDrop = factoryDrop;
    }

    public void Init(EnemyConfigSource enemyConfig)
    {
        _healthBar.Init(enemyConfig.Hp);
        _damageController.Init(enemyConfig.Hp);

        _damageController.OnTakeDamage += SyncHealthBar;
        _damageController.OnHealthEnded += HealthEnded;
    }

    private void SyncHealthBar(float currentHealth)
    {
        _healthBar.SyncHealthBar(currentHealth);
    }

    private void HealthEnded()
    {
        _factoryDrop.CreateDropAmmo(transform.position, Random.Range(2,8));
        Instantiate(_zombieDeadEffectPrefab);
        
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        _damageController.OnTakeDamage -= SyncHealthBar;
        _damageController.OnHealthEnded -= HealthEnded;
    }
}
