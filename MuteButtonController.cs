using UnityEngine;
using UnityEngine.UI;

public class MuteButtonController : MonoBehaviour
{
    public BackgroundMusicController musicController;
    private Button muteButton;
    private bool isMuted = false;

    void Start()
    {
        muteButton = GetComponent<Button>();
        muteButton.onClick.AddListener(ToggleMute);
    }

    void ToggleMute()
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            musicController.StopMusic(); // Müzik durdurulacak
            muteButton.GetComponentInChildren<Text>().text = ""; // Buton metnini değiştir
        }
        else
        {
            musicController.PlayMusic(); // Müzik oynatılacak
            muteButton.GetComponentInChildren<Text>().text = ""; // Buton metnini değiştir
        }
    }
}
