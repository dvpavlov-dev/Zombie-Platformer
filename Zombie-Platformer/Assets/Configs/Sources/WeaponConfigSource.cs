using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Configs/Weapon Config")]
public class WeaponConfigSource : ScriptableObject
{
    public float Damage;
    public int StartAmmo;
}
