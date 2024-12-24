using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TurboButtonController : MonoBehaviour
{
    public Button turboButton; // Turbo butonuna referans
    private bool isTurboActive = false; // Turbo aktif mi?

    private void Start()
    {
        // Başlangıçta butonu devre dışı bırakıyoruz
        turboButton.interactable = false;
        turboButton.onClick.AddListener(ActivateTurbo); // Butona tıklama olayını ekliyoruz
    }

    // Turbo modunu etkinleştiren fonksiyon
    public void ActivateTurbo()
    {
        if (isTurboActive)
            return;

        StartCoroutine(TurboCoroutine());
    }

    private IEnumerator TurboCoroutine()
    {
        isTurboActive = true;
        turboButton.interactable = false; // Butonu devre dışı bırak

        // Turbo süresi boyunca arabanın hızını artır
        CarController.Instance.ActivateTurboMode(); // Turbo modunu etkinleştir

        yield return new WaitForSeconds(2f); // 2 saniye turbo süresi

        CarController.Instance.DeactivateTurboMode(); // Turbo modunu devre dışı bırak
        isTurboActive = false;
    }

    // Butonu etkinleştiren fonksiyon
    public void EnableTurboButton()
    {
        turboButton.interactable = true;
    }
}
