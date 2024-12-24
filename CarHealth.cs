using UnityEngine;
using UnityEngine.UI;

public class CarHealth : MonoBehaviour
{
    public float maxHealth = 100f;    
    private float currentHealth;      
    public Image healthBar;           
    private GameManager gameManager;  

    
    void Start()
    {
        currentHealth = maxHealth;    
        UpdateHealthBar();            /
        
        
        gameManager = FindObjectOfType<GameManager>();
    }

    
    void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;

        
        if (currentHealth > maxHealth * 0.5f)
            healthBar.color = Color.green;   
        else if (currentHealth > maxHealth * 0.2f)
            healthBar.color = Color.yellow;  
        else
            healthBar.color = Color.red;    
    }

    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; 
        if (currentHealth < 0)
            currentHealth = 0;   

        UpdateHealthBar();  

        
        if (currentHealth <= 0 && gameManager != null)
        {
            gameManager.GameOver();
        }
    }

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PoliceCar")) 
        {
            TakeDamage(10f); 
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthBox")) 
        {
            IncreaseHealth(15f); 
            Destroy(other.gameObject); 
        }
    }

    
    public void IncreaseHealth(float percent)
    {
        if (currentHealth < maxHealth) 
        {
            float healthToAdd = maxHealth * (percent / 100);
            currentHealth = Mathf.Min(currentHealth + healthToAdd, maxHealth); 
            UpdateHealthBar(); 
        }
    }
}
