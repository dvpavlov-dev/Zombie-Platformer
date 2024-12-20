public class FactoryBullet : MonoBehaviour, IFactoryBullet
{
    [SerializeField] private GameObject _bulletPrefab;

    public GameObject CreateBullet()
    {
        return Instantiate(_bulletPrefab);
    }
}
