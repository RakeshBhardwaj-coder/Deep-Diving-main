using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ //Singlton
    private static PlayerMovement _instance;

    public static PlayerMovement Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PlayerMovement>();
            }

            return _instance;
        }
    }
    float normalMoveSpeed; // Adjust this value to control movement speed
    float boostedMoveSpeed; // Speed when Shift is held
    bool isBoosted = false;
    private bool facingLeft = false;
    public bool canMove=true;
    private Rigidbody2D rb;
    float horizontalInput;
    float verticalInput;

    public GameObject player;
    //mobile inputs
    private Vector2 touchStartPosition;
    bool isMoving;
    private float lastTapTime;
    public float doubleTapTimeThreshold = 0.3f;
    public Joystick joystick;

    public Vector2 playerInitialPosition;
    private void Update()
    {
       
        // Check if the current platform is mobile
#if UNITY_ANDROID || UNITY_IOS
        HandleMobileInput();

#else
        if (canMove)
        {
            // Check if Shift key is held down
            isBoosted = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            Movement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), isBoosted);
        }
#endif
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        normalMoveSpeed = GameManager.Instance.normalMoveSpeed;
        boostedMoveSpeed = GameManager.Instance.boostedMoveSpeed;
        playerInitialPosition = new Vector2(-5.22f, -.63f);
        player.transform.position = playerInitialPosition;

    }

    void HandleMobileInput()
    {
        isBoosted = GameManager.Instance.isBoosted; //is boosted can be get by the bool value in inspector
        Movement(joystick.Horizontal, joystick.Vertical, isBoosted);

       
    }


    void Movement(float horizontalInput, float verticalInput,bool isBoosted)
    {
       
      

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement = movement.normalized;

       

        // Choose the appropriate move speed based on the Shift key
        float currentMoveSpeed = isBoosted ? boostedMoveSpeed : normalMoveSpeed;
        rb.velocity = movement * currentMoveSpeed;

        // Set animation parameters based on movement
        if (isBoosted && movement.magnitude > 0.1f)
        {
            PlayerAnimation.Instance.DivingAnimation(isBoosted);
        }
        else if (!isBoosted && movement.magnitude > 0.1f)
        {

            PlayerAnimation.Instance.SwimmingAnimation();
            PlayerAnimation.Instance.DivingAnimation(isBoosted);
            TutorialManager.Instance.FirstMove();

        }
        else
        {
            PlayerAnimation.Instance.DivingAnimation(isBoosted);
            PlayerAnimation.Instance.IdealAnimation();
        }

        // Flip the character sprite based on movement direction

        float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;

        // Flip the angle if the x-coordinate is negative
        if (movement.x > 0f)
        {
            // Apply the rotation and location to the object
            transform.localScale = new Vector3(1, 1, 1); // Facing right
            facingLeft = false;

            if (movement.y > 0f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
            else if (movement.y < 0f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
        }
        else if (movement.x < 0f)
        {
            // Apply the rotation and location to the object
            transform.localScale = new Vector3(-1, 1, 1); // Facing Left
            facingLeft = true;
            angle += 180f;
            if (movement.y > 0f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
            else if (movement.y < 0f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
        }
        else if (movement.y > 0f)
        {
            if (!facingLeft)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
                // Facing Left
            }
            else
            {
                angle += 180f;
                transform.rotation = Quaternion.Euler(0f, 0f, angle);

            }


        }
        else if (movement.y < 0f)
        {
            if (!facingLeft)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
                // Facing Left
            }
            else
            {
                angle += 180f;
                transform.rotation = Quaternion.Euler(0f, 0f, angle);

            }
        }
        else if (!facingLeft && movement.y == 0f)
        {
            // Apply the rotation to the object
            transform.localScale = new Vector3(1, 1, 1); // Facing right
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        }
        else if (facingLeft && movement.y == 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Facing left
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);


        }
    }

   
}
