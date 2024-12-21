using UnityEngine;
using Zenject;
using Zombie_Platformer.Infrastructure;

public class PlayerAttackComponent : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _shootPoint;
    
    private IInputService _inputService;
    private IFactoryBullet _factoryBullet;
    private IGameProcess _gameProcess;
    private Configs _configs;
    private IUIController _uiController;

    private bool _isFire;
    private int _ammo;

    [Inject]
    private void Constructor(IInputService inputService, IFactoryBullet factoryBullet, Configs configs, IGameProcess gameProcess, IUIController uiController)
    {
        _uiController = uiController;
        _gameProcess = gameProcess;
        _configs = configs;
        _factoryBullet = factoryBullet;
        _inputService = inputService;
    }

    private void Start()
    {
        _ammo = _configs.WeaponConfig.StartAmmo;
        _uiController.ShowAmmoCount(_ammo);
    }

    void Update()
    {
        if (_gameProcess.IsGameOver)
        {
            _animator.SetBool("Fire", false);
            return;
        }
        
        if (_inputService.Fire && !_isFire)
        {
            _isFire = true;
            GameObject bullet = _factoryBullet.GetBullet(transform.right, _configs.WeaponConfig.Damage);
            bullet.transform.position = _shootPoint.position;

            _ammo--;
            _uiController.ShowAmmoCount(_ammo);
            _animator.SetBool("Fire", true);

            if (_ammo <= 0)
            {
                _gameProcess.IsGameOver = true;
            }
                
            Invoke(nameof(FireIsOver), 0.2f);
        }
    }

    private void FireIsOver()
    {
        _isFire = false;
        _animator.SetBool("Fire", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<DropAmmoController>() is {} ammoDropController)
        {
            _ammo += ammoDropController.AmountAmmo;
            _uiController.ShowAmmoCount(_ammo);
            
            Destroy(other.gameObject);
        }
    }
}
