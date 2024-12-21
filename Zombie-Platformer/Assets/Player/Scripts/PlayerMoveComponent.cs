using UnityEngine;
using Zenject;
using Zombie_Platformer.Infrastructure;

namespace Zombie_Platformer
{
    public class PlayerMoveComponent : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private IInputService _inputService;
        private Configs _configs;
        private IGameProcess _gameProcess;

        [Inject]
        private void Constructor(IInputService inputService, Configs configs, IGameProcess gameProcess)
        {
            _gameProcess = gameProcess;
            _configs = configs;
            _inputService = inputService;
        }
        
        private void Update()
        {
            if (_gameProcess.IsGameOver)
            {
                _animator.SetBool("Move", false);
                return;
            }
            
            if (_inputService.HorizontalAxis != 0 && !_inputService.Fire)
            {
                transform.position = new Vector3(transform.position.x + (_inputService.HorizontalAxis * Time.deltaTime * _configs.PlayerConfig.Speed), transform.position.y,transform.position.z);
                transform.rotation = Quaternion.Euler(0,_inputService.HorizontalAxis < 0 ? 180 : 0, 0);
                _animator.SetBool("Move", true);
            }
            else
            {
                _animator.SetBool("Move", false);
            }
        }
    }
}