using UnityEngine;
using UnityEngine.UI;

public class CarHealth : MonoBehaviour
{
    public float maxHealth = 100f;    // Maksimum can
    private float currentHealth;      // Mevcut can
    public Image healthBar;           // UI Image (Can barı)
    private GameManager gameManager;  // GameManager referansı

    // Start metodu
    void Start()
    {
        currentHealth = maxHealth;    // Başlangıçta can maksimum
        UpdateHealthBar();            // Can barını güncelle
        
        // GameManager referansını bul
        gameManager = FindObjectOfType<GameManager>();
    }

    // Can barını güncelle
    void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;

        // Can azaldıkça renk değişsin
        if (currentHealth > maxHealth * 0.5f)
            healthBar.color = Color.green;   // Yeşil (50% ve üzeri)
        else if (currentHealth > maxHealth * 0.2f)
            healthBar.color = Color.yellow;  // Sarı (20%-50% arası)
        else
            healthBar.color = Color.red;     // Kırmızı (20%'nin altı)
    }

    // Canı azaltmak için kullanılan fonksiyon
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;  // Sağlık azalır
        if (currentHealth < 0)
            currentHealth = 0;   // Can sıfırın altına düşmesin

        UpdateHealthBar();  // Can barını güncelle

        // Can sıfıra düştüyse GameOver çağır
        if (currentHealth <= 0 && gameManager != null)
        {
            gameManager.GameOver();
        }
    }

    // Çarpışma olduğunda canı azalt
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PoliceCar")) // Polis arabası ile çarpışma
        {
            TakeDamage(10f); // Polis arabası her çarptığında 10 can eksilsin
        }
    }

    // Sağlık kutusuna dokunduğunda canı artır
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthBox")) // Sağlık kutusuna çarpma
        {
            IncreaseHealth(15f); // Sağlığı %15 artır
            Destroy(other.gameObject); // Sağlık kutusunu yok et
        }
    }

    // Canı artırmak için kullanılan fonksiyon
    public void IncreaseHealth(float percent)
    {
        if (currentHealth < maxHealth) // Eğer can maksimum değilse
        {
            float healthToAdd = maxHealth * (percent / 100);
            currentHealth = Mathf.Min(currentHealth + healthToAdd, maxHealth); // Canı maksimum değeri aşmadan artır
            UpdateHealthBar();  // Can barını güncelle
        }
    }
}
