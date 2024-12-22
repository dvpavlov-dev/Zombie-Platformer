using UnityEngine;
using Zenject;
using Zombie_Platformer.Infrastructure;

namespace Zombie_Platformer.Player
{
    public class PlayerAttackComponent : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private AudioSource _audioSource;

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
            _uiController.ShowAmountAmmo(_ammo);
        }

        void Update()
        {
            if (_gameProcess.IsGameOver)
            {
                _animator.SetBool("Fire", false);
                return;
            }

            if (_inputService.Fire)
            {
                if(!_isFire)
                {
                    _isFire = true;
                    GameObject bullet = _factoryBullet.GetBullet(transform.right, _configs.WeaponConfig.Damage);
                    bullet.transform.position = _shootPoint.position;

                    _ammo--;
                    _uiController.ShowAmountAmmo(_ammo);
                    _animator.SetBool("Fire", true);
                    _audioSource.Play();

                    if (_ammo <= 0)
                    {
                        _gameProcess.IsGameOver = true;
                    }

                    Invoke(nameof(FireIsOver), 0.2f);
                }
            }
            else
            {
                _animator.SetBool("Fire", false);
            }
        }

        private void FireIsOver()
        {
            _isFire = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<DropAmmoController>() is {} ammoDropController)
            {
                _ammo += ammoDropController.TakeDropAmmo();
                _uiController.ShowAmountAmmo(_ammo);
            }
        }
    }
}