using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public bool isJumping = false;
    public float jumpHeight = 3f;    

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [SerializeField] private UIController uiController;
    private int points = 0;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //IS GROUNDED 

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        /*if(isGrounded)        GROUND DEBUG
        {
            Debug.Log("ground");
        }*/

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            isJumping = false;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //JUMPING

        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isJumping = true;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Pickup>() != null) //true jeśli other zawiera Pickup, false jeśli go nie zawiera
        {
            points += other.GetComponent<Pickup>().Collect(); // += to skrót od points = points + x;
            uiController.UpdatePoints(points);
        }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count++;
            script.UpdateStars(count);
        }
    }*/

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<StarsController>() != null) //true jeśli other zawiera Pickup, false jeśli go nie zawiera
        {
            points += other.GetComponent<StarsController>().Collect(); // += to skrót od points = points + x;
            uiController.UpdateStars(points);
        }
    }
}
