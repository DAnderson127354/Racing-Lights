using UnityEngine;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour
{
    CharacterController charCont;

    private Vector3 moveDirection = Vector3.zero;   //Creates a new vector3 variable that will be used to define how the player will move. Gives it an initial value of zero for all three values.
    public float speed;                     //Creates a new float variable that will store a speed modifier for the player. "f" denotes the number as a float value. "public" will create a little box in the inspector that you can modify.
    public float gravity;
    public float jumpSpeed;
    public float pushSpeed;
    public DistanceLeft winCondition;
    public Text winText;
    public FinishRace raceDone;

    private bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private void Start()        //Anything here will happen at the start of the scene.
    {
        charCont = GetComponent<CharacterController>(); //Finds and stores the reference to the character controller component
    }


    void Update()              //Anything here happens once per frame.
    {
        if (raceDone.Finish())
        {
            speed = 0;
        }

        if (winCondition.Win())
        {
            winText.text = "You Won!";
            raceDone.Finish();
        }

        //checking to see if player is on the ground to jump and move around
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && moveDirection.y < 0f)
            moveDirection.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        charCont.Move(move * speed * Time.deltaTime);

        moveDirection.y += gravity * Time.deltaTime;
        charCont.Move(moveDirection * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            moveDirection.y = Mathf.Sqrt(jumpSpeed * gravity * -2f);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

    }

    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Block")
        {
            if (collision.gameObject.transform.position.z >= 102f)
            {
                //keep block in place
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;     
            }
            // Apply the push
            collision.gameObject.GetComponent<Rigidbody>().AddForce(0, 0, pushSpeed);

            collision.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Block")
        {
            if (collision.gameObject.transform.position.z < 102f)
            {
                collision.gameObject.GetComponent<Renderer> ().material.color = Color.white;
            }
        }
    }


}
