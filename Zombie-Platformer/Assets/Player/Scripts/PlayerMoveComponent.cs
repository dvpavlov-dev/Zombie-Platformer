using UnityEngine;
using Zenject;
using Zombie_Platformer.Infrastructure;

namespace Zombie_Platformer
{
    public class PlayerMoveComponent : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private IInputService _inputService;
        
        [Inject]
        private void Constructor(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        private void Update()
        {
            if (_inputService.HorizontalAxis != 0 && !_inputService.Fire)
            {
                transform.position = new Vector3(transform.position.x + (_inputService.HorizontalAxis * Time.deltaTime * _speed), transform.position.y,transform.position.z);
                transform.rotation = Quaternion.Euler(0,_inputService.HorizontalAxis < 0 ? 180 : 0, 0);
            }
        }
    }
}