using UnityEngine;
using Zenject;
using Zombie_Platformer.Infrastructure;

public class PlayerAttackComponent : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    
    private IInputService _inputService;
    private IFactoryBullet _factoryBullet;

    private bool _isFire;

    [Inject]
    private void Constructor(IInputService inputService, IFactoryBullet factoryBullet)
    {
        _factoryBullet = factoryBullet;
        _inputService = inputService;
    }
    
    void Update()
    {
        if (_inputService.Fire && !_isFire)
        {
            _isFire = true;
            GameObject bullet = _factoryBullet.GetBullet(transform.right);
            bullet.transform.position = _shootPoint.position;
                
            Invoke(nameof(FireIsOver), 0.2f);
        }
    }

    private void FireIsOver()
    {
        _isFire = false;
    }
}
