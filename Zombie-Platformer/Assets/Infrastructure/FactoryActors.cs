using UnityEngine;
public class FactoryActors : MonoBehaviour, IFactoryActors
{
    [Header("Player")]
    [SerializeField] private GameObject _payerPrefab;

    public GameObject CreatePlayer()
    {
        return Instantiate(_payerPrefab);
    }
}
