using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    public static CarController Instance;

    public float moveSpeed = 30f;             // Arabanın normal hızı
    public float turboSpeed = 45f;            // Arabanın turbo hızı
    public float turnSpeed = 50f;             // Arabanın dönüş hızı
    public JoystickController joystick;       // Joystick script'ine referans
    public Button turboButton;                // Turbo butonuna referans

    private Rigidbody rb;
    private bool isTurboActive = false;       // Turbo modu aktif mi?
    private float currentSpeed;               // Anlık hız
    private int collectedCoins = 0;           // Toplanan altın sayısı
    private float verticalInput;              // Dikey giriş
    private float horizontalInput;            // Yatay giriş

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Devrilmeyi önlemek için rotasyonu kilitle

        currentSpeed = moveSpeed; // Başlangıçta normal hızla başla

        turboButton.interactable = false;     // Turbo butonunu başlangıçta devre dışı bırak
        turboButton.onClick.AddListener(ActivateTurbo);
    }

    void Update()
    {
        // Girişleri Update'de kontrol et
        verticalInput = joystick.Vertical();
        horizontalInput = joystick.Horizontal();
    }

    void FixedUpdate()
    {
        // Fiziksel hareketi FixedUpdate'de uygula
        Vector3 moveDirection = transform.forward * verticalInput * currentSpeed;
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z); // Y eksenindeki mevcut hızı koru

        if (verticalInput != 0)
        {
            float turn = horizontalInput * turnSpeed * Time.fixedDeltaTime;
            Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bina"))
        {
            // Bina ile çarpışmada yapılacak işlemler
        }
    }

    public void CollectCoin()
    {
        collectedCoins++;

        if (collectedCoins % 25 == 0)
        {
            EnableTurboButton();
        }
    }

    public void ActivateTurbo()
    {
        if (isTurboActive)
            return;

        StartCoroutine(TurboCoroutine());
    }

    private IEnumerator TurboCoroutine()
    {
        ActivateTurboMode(); // Turbo modunu etkinleştir

        yield return new WaitForSeconds(2f); // 2 saniye turbo süresi

        DeactivateTurboMode(); // Turbo modunu devre dışı bırak
    }

    private void EnableTurboButton()
    {
        turboButton.interactable = true;
    }

    // Turbo modu etkinleştiren metod
    public void ActivateTurboMode()
    {
        isTurboActive = true;
        currentSpeed = turboSpeed;  // Turbo hızını aktif et
    }

    // Turbo modunu devre dışı bırakan metod
    public void DeactivateTurboMode()
    {
        isTurboActive = false;
        currentSpeed = moveSpeed;   // Normal hıza geri dön
    }
}
