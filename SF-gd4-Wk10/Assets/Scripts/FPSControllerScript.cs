using UnityEngine;

public class FPSControllerScript : MonoBehaviour
{
    private Camera playerCamera; //gives ability to manipulate camera

    [SerializeField] float moveSpeed = 10f; //player movement speed
    [SerializeField] float runMultiplyer = 1.5f; //how fast a player can run relative to moveSpeed                                       
    [SerializeField] float jumpForce = 5; //how high player can jump
    [SerializeField] float gravity = 10f; //gravity applied to the player when on the ground
    public float mouseSensitivity = 2f; //how sensitive camera movement is based on mouse input
    [SerializeField] float lookXLimit = 60f; //player up and down look angle
    float rotationX = 0; //stores rotation of camera
    Vector3 moveDirection; //represents player move direction
    CharacterController controller; //gives access to player charracter controller



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = Camera.main;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        #region Movement

        if (controller.isGrounded)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            float movementDirectionY = moveDirection.y;

            moveDirection = (horizontalInput * transform.right) + (verticalInput * transform.forward);

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;

            }
            else
            {
                moveDirection.y = movementDirectionY;         
            
            }


        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;

        }     

        if (Input.GetKeyDown(KeyCode.LeftShift)) moveSpeed *= runMultiplyer;
        if (Input.GetKeyUp(KeyCode.LeftShift)) moveSpeed /= runMultiplyer;

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        #endregion



        #region Rotation

        transform.Rotate(Vector3.up * mouseSensitivity * Time.deltaTime * Input.GetAxis("Mouse X"));

        rotationX += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        #endregion

    }
}
