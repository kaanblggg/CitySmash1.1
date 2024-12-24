using UnityEngine;

public class HealthBox : MonoBehaviour
{
    public float healthIncreasePercent = 15f;  // Sağlık kutusunun artıracağı can yüzdesi

    public float lifetime = 10f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Arabayla çarpışma
        {
            CarHealth carHealth = other.GetComponent<CarHealth>();
            if (carHealth != null)
            {
                carHealth.IncreaseHealth(healthIncreasePercent); // Canı %15 artır
                Destroy(gameObject); // Can kutusunu yok et
            }
        }
    }
}
