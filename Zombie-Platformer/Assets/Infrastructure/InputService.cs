using UnityEngine;

namespace Zombie_Platformer.Infrastructure
{
    public class InputService : IInputService
    {
        private const string HORIZONTAL_AXIS = "Horizontal";
        private const string FIRE = "Fire1";

        public float HorizontalAxis => Input.GetAxis(HORIZONTAL_AXIS);
        public bool Fire => Input.GetButton(FIRE);
    }
}
