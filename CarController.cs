using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    public static CarController Instance;

    public float moveSpeed = 30f;             
    public float turboSpeed = 45f;            
    public float turnSpeed = 50f;             
    public JoystickController joystick;        
    public Button turboButton;                   

    private Rigidbody rb;
    private bool isTurboActive = false;          
    private float currentSpeed;                
    private int collectedCoins = 0;            
    private float verticalInput;              
    private float horizontalInput;            

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
        rb.freezeRotation = true; 

        currentSpeed = moveSpeed; 

        turboButton.interactable = false;     
        turboButton.onClick.AddListener(ActivateTurbo);
    }

    void Update()
    {
       
        verticalInput = joystick.Vertical();
        horizontalInput = joystick.Horizontal();
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = transform.forward * verticalInput * currentSpeed;
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z); 

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
        ActivateTurboMode(); 

        yield return new WaitForSeconds(2f); 

        DeactivateTurboMode();
    }

    private void EnableTurboButton()
    {
        turboButton.interactable = true;
    }

    
    public void ActivateTurboMode()
    {
        isTurboActive = true;
        currentSpeed = turboSpeed;  
    }

    
    public void DeactivateTurboMode()
    {
        isTurboActive = false;
        currentSpeed = moveSpeed;   
    }
}
