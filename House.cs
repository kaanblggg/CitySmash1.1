using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public int health = 25;
    public GameObject destructionEffect;
    public GameObject coinPrefab;
    private bool isDestroyed = false;  // Binanın yalnızca bir kez yok edilmesi için

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject); // Mermiyi yok et
            health--;

            if (health <= 0 && !isDestroyed)
            {
                DestroyBuilding();
            }
        }
    }

    void DestroyBuilding()
    {
        isDestroyed = true;  // Binanın yok edildiğini işaretle

        // Yıkılma efektini tetikle
        GameObject effect = Instantiate(destructionEffect, transform.position, Quaternion.identity);
        ParticleSystem ps = effect.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
        }
        Destroy(effect, 1.5f);

        // Rastgele coin sayısını belirle
        int coinCount = Random.Range(1, 6);
        for (int i = 0; i < coinCount; i++)
        {
            Vector3 coinPosition = transform.position + Vector3.up + new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));
            Instantiate(coinPrefab, coinPosition, Quaternion.identity);
        }

        // Binayı görünmez yap ve yeniden oluşturmak için HouseSpawner’a bilgi gönder
        gameObject.SetActive(false);
        HouseSpawner.Instance.RespawnHouse(this.gameObject, 10f);  // 5 saniye sonra yeniden oluştur
    }

    public void ResetHouse()
    {
        health = 5; // Sağlık durumunu sıfırla
        isDestroyed = false; // Binanın yok edilme durumunu sıfırla
        gameObject.SetActive(true); // Binayı tekrar görünür yap
    }
}
