using UnityEngine;
using Zombie_Platformer.Player;

namespace Zombie_Platformer.Infrastructure
{
    public class FactoryDrop : MonoBehaviour, IFactoryDrop
    {
        [SerializeField] private GameObject _ammoDropPrefab;

        public GameObject CreateDropAmmo(Vector3 spawnPos, int amountAmmo)
        {
            GameObject dropAmmo = Instantiate(_ammoDropPrefab, spawnPos, Quaternion.identity);
            dropAmmo.GetComponent<DropAmmoController>().Init(amountAmmo);

            return dropAmmo;
        }
    }

}