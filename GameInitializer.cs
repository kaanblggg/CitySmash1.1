using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public GameObject bulletPrefab;    // Mermi prefab
    public GameObject explosionPrefab; // Patlama efekti prefab
    public GameObject housePrefab;     // Bina prefab

    void Start()
    {
        ObjectPoolManager.Instance.CreatePool(bulletPrefab, 20);    // 20 mermi
        ObjectPoolManager.Instance.CreatePool(explosionPrefab, 10); // 10 patlama efekti
        ObjectPoolManager.Instance.CreatePool(housePrefab, 5);      // 5 bina
    }
}
