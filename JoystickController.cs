using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    
    private Image joystickBackground;    // Joystick'in arka planı
    private Image joystickHandle;        // Joystick'in kontrol noktası
    private Vector2 inputVector;         // Hareket vektörü
    public JoystickController joystick;
    

    void Start()
    {
        joystickBackground = GetComponent<Image>();     // Arka plan resmi
        joystickHandle = transform.GetChild(0).GetComponent<Image>();   // Kontrol noktası
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        // Joystick'in boyutları içinde tıklanan noktayı bul
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground.rectTransform, eventData.position, eventData.pressEventCamera, out position))
        {
            // Pozisyonu normalize ederek, joystick'in yarıçapı içinde kalmasını sağla
            position.x = (position.x / joystickBackground.rectTransform.sizeDelta.x);
            position.y = (position.y / joystickBackground.rectTransform.sizeDelta.y);

            inputVector = new Vector2(position.x * 2, position.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            // Joystick kontrol noktasını hareket ettir
            joystickHandle.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBackground.rectTransform.sizeDelta.x / 2), inputVector.y * (joystickBackground.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);   // Joystick'e dokunulduğunda da aynı işlemi yap
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;    // Joystick bırakıldığında dur
        joystickHandle.rectTransform.anchoredPosition = Vector2.zero;  // Joystick ortasına geri döner
    }

    public float Horizontal()
    {
        return inputVector.x;  // X eksenindeki hareket
    }

    public float Vertical()
    {
        return inputVector.y;  // Y eksenindeki hareket
    }
}
