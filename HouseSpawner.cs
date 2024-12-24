using System.Collections;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    public static HouseSpawner Instance;

    void Awake()
    {
        // Singleton yapısı ile tek bir HouseSpawner instance’ı oluştur
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void RespawnHouse(GameObject house, float delay)
    {
        StartCoroutine(RespawnRoutine(house, delay));
    }

    private IEnumerator RespawnRoutine(GameObject house, float delay)
    {
          // Bekleme sırasında konsola bilgi ver
        yield return new WaitForSeconds(delay);

        // House script'ini al ve binayı sıfırla
        House houseScript = house.GetComponent<House>();
        if (houseScript != null)
        {
            houseScript.ResetHouse();  // Binayı yeniden aktif hale getir
           
        }
    }
}
