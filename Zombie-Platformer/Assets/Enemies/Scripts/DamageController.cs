using System;
using UnityEngine;

namespace Zombie_Platformer.Enemy
{
    public class DamageController : MonoBehaviour
    {
        public Action<float> OnTakeDamage;
        public Action OnHealthEnded;

        private float _currentHealth;

        public void Init(float health)
        {
            _currentHealth = health;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            OnTakeDamage?.Invoke(_currentHealth);

            if (_currentHealth <= 0)
            {
                OnHealthEnded?.Invoke();
            }
        }
    }
}