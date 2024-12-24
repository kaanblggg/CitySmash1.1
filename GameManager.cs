using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;   // Game Over paneli referansı
    public int health = 100;           // Başlangıç sağlık değeri

    private void Start()
    {
        InitializePoliceCars();
        gameOverPanel.SetActive(false); // Oyun başlarken Game Over paneli gizli
    }

    private void Update()
    {
        // Sağlık sıfıra düştüğünde Game Over fonksiyonunu çağır
        if (health <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true); // Game Over panelini göster
        Time.timeScale = 0f;           // Oyunu durdur
      //  Debug.Log("Game Over");        // Konsola Game Over yazdır
    }

    public void RetryGame()
    {
        Time.timeScale = 1f; // Zamanı yeniden başlat
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Mevcut sahneyi yeniden yükle
         SetPoliceCarsSettings();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        health = 100;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        InitializePoliceCars();
    }
     private void InitializePoliceCars()
    {
        GameObject[] policeCars = GameObject.FindGameObjectsWithTag("PoliceCar");
        foreach (GameObject policeCar in policeCars)
        {
            PoliceAI policeAI = policeCar.GetComponent<PoliceAI>();
            if (policeAI != null)
            {
                policeAI.enabled = false;
                policeAI.enabled = true;
            }
        }
    }
    private void SetPoliceCarsSettings()
{
    GameObject[] policeCars = GameObject.FindGameObjectsWithTag("PoliceCar");
    foreach (GameObject policeCar in policeCars)
    {
        PoliceAI policeAI = policeCar.GetComponent<PoliceAI>();
        if (policeAI != null)
        {
            policeAI.enabled = false; // Bileşeni devre dışı bırak
            policeAI.enabled = true;  // Bileşeni tekrar etkinleştir
        }
    }
}
    public void QuitGame()
    {
        Application.Quit(); // Oyundan çık
    }

    // Sağlık azaltma fonksiyonu
    public void TakeDamage(int damage)
    {
        health -= damage;  // Sağlık değerini azalt
    }
}
