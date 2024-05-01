using UnityEngine;
using UnityEngine.UI;
using TPS;

public class PlayerMovement : MonoBehaviour
{
    [Header("Values")]
    public float speed; 
    public float mouseSensivity;
    float defaultSpeed;
    float currentRotationX = 0f;
    public static float mainHealth;
    [Header("Bools")]
    bool isGrounded = true;
    //bool isMoving;
    bool speedInitialized;
    bool leftShift;
    bool leftControl;
    bool forwardMove;
    bool rightMove;
    bool leftMove;
    bool backMove;
    [Header("Component")]
    Rigidbody rb;
    public static Animator mainAnimation;
    public UIControl uýControl;
    [Header("Class")]
    Animations animationsClass = new Animations();
    [Header("UISettings")]
    public Image healthBar;
    [Header("AnimationValue")]
    float[] ForwardValue = { .2f, .5f, 1.5f, 2f, 4f, 3.5f, 1f };
    float[] BackwardsValue = { .2f, .5f, 1.5f, 2f, 4f, 3.5f, 1f };
    float[] RightValue = { .2f, 1.5f, 2f, 2.5f, 1f, .5f };
    float[] LeftValue = { .2f, 1.5f, 2f, 2.5f, 1f, .5f };
    


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        defaultSpeed = speed;
        mainAnimation = GetComponent<Animator>();
        
        mainHealth = 100;
    }


    void Update()
    {

        HandleMovement();
        HandleMouseLook();
        Jump();
        SpeedController();
        Animations();
        healthBar.fillAmount = mainHealth / 100;
    }

    public void HealthControl(int HitPower)
    {
        mainHealth-=HitPower;
        Debug.Log(mainHealth);
        if (mainHealth<=0)
        {
            Debug.LogWarning("DID!");
        }
    }
    void HandleMovement()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            forwardMove = true;
            //isMoving = true;
            if (!speedInitialized)
            {
                speed = 3;
                speedInitialized = true;
            }

            float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            transform.Translate(horizontal, 0, vertical);



        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            forwardMove = false;
            //isMoving = false;
            speedInitialized = false;
            speed = defaultSpeed * 0;

        }
        if (Input.GetKey(KeyCode.A) && !forwardMove && !rightMove && !backMove)
        {
            leftMove = true;
            //isMoving = false;
            if (!speedInitialized)
            {
                speed = 3;
                speedInitialized = true;
            }

            float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            transform.Translate(horizontal, 0, vertical);



        }

        else if (Input.GetKeyUp(KeyCode.A))
        {
            leftMove = false;
            speedInitialized = false;
            speed = defaultSpeed * 0;


        }
        if (Input.GetKey(KeyCode.D) && !forwardMove && !leftMove && !backMove)
        {
            mainAnimation.SetBool("right", true);
            rightMove = true;
            //isMoving = false;
            if (!speedInitialized)
            {
                speed = 3;
                speedInitialized = true;
            }

            float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            transform.Translate(horizontal, 0, vertical);



        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            rightMove = false;
            speedInitialized = false;
            mainAnimation.SetBool("right", false);


        }
        if (Input.GetKey(KeyCode.S) && !forwardMove && !rightMove && !leftMove)
        {
            backMove = true;
            //isMoving = false;
            if (!speedInitialized)
            {
                speed = 3;
                speedInitialized = true;
            }
            float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            transform.Translate(horizontal, 0, vertical);


        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            backMove = false;
            speedInitialized = false;
            speed = defaultSpeed * 0;

        }



    }
    void Animations()
    {
        if (mainHealth>0 && uýControl.Win.activeSelf==false)
        {
            animationsClass.Forward(mainAnimation, "isForward", ForwardValue, backMove, rightMove, leftMove, leftShift);
            animationsClass.Backwards(mainAnimation, "isBackwards", BackwardsValue, forwardMove, rightMove, leftMove, leftShift);
            animationsClass.Right(mainAnimation, "isRight", RightValue, leftMove, backMove);
            animationsClass.Left(mainAnimation, "isLeft", LeftValue, rightMove, backMove);
            
        }
        
    }
    void HandleMouseLook()
    {
        if (mainHealth>0 && uýControl.Win.activeSelf==false)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity;

            currentRotationX -= mouseY;
            currentRotationX = Mathf.Clamp(currentRotationX, -25f, 25f);

            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + mouseX, 0);
            Camera.main.transform.localRotation = Quaternion.Euler(currentRotationX, 0, 0);
        }
        
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(0, 5, 0, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void SpeedController()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && !leftControl && !backMove)
        {

            leftShift = true;
            speed *= 1.5f;

        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !leftControl)
        {
            leftShift = false;
            speed = defaultSpeed;

        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && !leftShift && isGrounded)
        {
            leftControl = true;
            speed /= 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) && !leftShift && isGrounded)
        {
            leftControl = false;
            speed = defaultSpeed;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Winning"))
        {
            uýControl.WinFNC();

        }
    }
    
}
