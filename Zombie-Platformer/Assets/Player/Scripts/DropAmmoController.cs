using TMPro;
using UnityEngine;

namespace Zombie_Platformer.Player
{
    public class DropAmmoController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _amountAmmoText;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Collider2D _physicsCollider;
        [SerializeField] private Collider2D _triggerCollider;
        [SerializeField] private GameObject _dropImage;

        private int _amountAmmo;

        public void Init(int amountAmmo)
        {
            _amountAmmo = amountAmmo;
            _amountAmmoText.text = amountAmmo.ToString();
        }

        public int TakeDropAmmo()
        {
            _audioSource.Play();
            _physicsCollider.enabled = false;
            _triggerCollider.enabled = false;
            _dropImage.SetActive(false);
            Destroy(gameObject, 0.5f);

            return _amountAmmo;
        }
    }
}