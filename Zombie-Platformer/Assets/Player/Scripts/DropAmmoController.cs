using TMPro;
using UnityEngine;

public class DropAmmoController : MonoBehaviour
{
    [SerializeField] private TMP_Text _amountAmmoText;
    
    public int AmountAmmo { get; private set; }

    public void Init(int amountAmmo)
    {
        AmountAmmo = amountAmmo;
        _amountAmmoText.text = amountAmmo.ToString();
    }
}
