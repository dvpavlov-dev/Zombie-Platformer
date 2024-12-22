using UnityEngine;
using UnityEngine.UI;

namespace Zombie_Platformer.Enemy
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthImage;

        private float _maxHealth;

        public void Init(float maxHealth)
        {
            _maxHealth = maxHealth;
        }

        public void SyncHealthBar(float currentHealth)
        {
            if (currentHealth <= 0)
            {
                _healthImage.fillAmount = 0;
                return;
            }

            _healthImage.fillAmount = currentHealth / _maxHealth;
        }
    }
}