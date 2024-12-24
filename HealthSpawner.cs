using System.Collections;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject healthBoxPrefab;  // Sağlık kutusu prefab'i
    public Transform[] spawnPoints;     // Sağlık kutusunun çıkacağı noktalar
    public float spawnInterval = 10f;   // Can kutusunun çıkma aralığı (10 saniye)

    void Start()
    {
        StartCoroutine(SpawnHealthBox());
    }

    IEnumerator SpawnHealthBox()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval); // Belirli bir süre bekle

            // Rastgele bir spawn noktası seç
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(healthBoxPrefab, spawnPoints[randomIndex].position, Quaternion.identity); // Sağlık kutusunu yarat
        }
    }
}
