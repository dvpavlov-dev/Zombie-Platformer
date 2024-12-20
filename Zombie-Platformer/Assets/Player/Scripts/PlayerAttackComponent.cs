using UnityEngine;
using Zenject;
using Zombie_Platformer.Infrastructure;

public class PlayerAttackComponent : MonoBehaviour
{
    private IInputService _inputService;
    
    [Inject]
    private void Constructor(IInputService inputService)
    {
        _inputService = inputService;

    }
    
    void Update()
    {
        if (_inputService.Fire)
        {
            
        }
    }
}
