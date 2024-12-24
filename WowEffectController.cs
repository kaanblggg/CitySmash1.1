using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WowEffectController : MonoBehaviour
{
    public Text wowText;                   // WOW yazısını tutacak Text bileşeni
    public Text amazingText;               // AMAZING yazısını tutacak Text bileşeni
    public int wowTargetCoinCount = 15;    // WOW efekti için coin sayısı
    public int amazingTargetCoinCount = 50; // AMAZING efekti için coin sayısı
    public float displayDuration = 1.5f;   // Yazıların görünme süresi
    public AudioSource wowAudioSource;     // WOW efekti için ses kaynağı
    public AudioSource amazingAudioSource; // AMAZING efekti için ses kaynağı

    private int currentCoinCount = 0;      // Toplanan coin sayısını izlemek için
    private bool isWowEffectActive = false;      // WOW efektinin aktif olup olmadığını izlemek için
    private bool isAmazingEffectActive = false;   // AMAZING efektinin aktif olup olmadığını izlemek için

    void Start()
    {
        // Başlangıçta WOW ve AMAZING yazılarını gizle
        wowText.gameObject.SetActive(false);
        amazingText.gameObject.SetActive(false);
    }

    public void AddCoin()
    {
        currentCoinCount++;

        // 15 coin toplandığında WOW efekti
        if (currentCoinCount == wowTargetCoinCount && !isWowEffectActive)
        {
            StartCoroutine(ShowWowEffect());
        }

        // 50 coin toplandığında AMAZING efekti
        if (currentCoinCount == amazingTargetCoinCount && !isAmazingEffectActive)
        {
            StartCoroutine(ShowAmazingEffect());
        }
    }

    private IEnumerator ShowWowEffect()
    {
        isWowEffectActive = true;

        // WOW yazısını göster
        wowText.gameObject.SetActive(true);

        // WOW sesini oynat
        if (wowAudioSource != null)
        {
            wowAudioSource.Play();
        }

        // Belirtilen süre kadar bekle
        yield return new WaitForSeconds(displayDuration);

        // WOW yazısını tekrar gizle
        wowText.gameObject.SetActive(false);

        // Efekti yeniden kullanılabilir hale getir
        isWowEffectActive = false;
    }

    private IEnumerator ShowAmazingEffect()
    {
        isAmazingEffectActive = true;

        // AMAZING yazısını göster
        amazingText.gameObject.SetActive(true);

        // AMAZING sesini oynat
        if (amazingAudioSource != null)
        {
            amazingAudioSource.Play();
        }

        // Belirtilen süre kadar bekle
        yield return new WaitForSeconds(displayDuration);

        // AMAZING yazısını tekrar gizle
        amazingText.gameObject.SetActive(false);

        // Efekti yeniden kullanılabilir hale getir
        isAmazingEffectActive = false;
    }
}
