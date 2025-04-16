using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //Player Input
    private Vector2 input_vec = Vector2.zero;

    //Rotation
    private float rotate_speed = 200f; //In degrees

    //Components
    private Rigidbody2D rb;

    //Moving
    private float max_speed = 5.5f;
    private float acceleration = 13f;
    private Vector2 velocity = Vector2.zero;

    //Screen Wrapping
    public Camera cam;
    private Vector2 cam_bottom_left = Vector2.zero;
    private Vector2 cam_top_right = Vector2.zero;

    public void CaptureMoveInput (InputAction.CallbackContext context)
    {
        input_vec = context.ReadValue<Vector2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Get camera vectors in screen space. (Pixels)
        cam_top_right = new Vector2(cam.scaledPixelWidth, cam.scaledPixelHeight);

        //Convert them to world space.
        cam_bottom_left = cam.ScreenToWorldPoint(cam_bottom_left);
        cam_top_right = cam.ScreenToWorldPoint(cam_top_right);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Screen Wrapping
        //Right Side
        if (rb.position.x > cam_top_right.x)
        {
            rb.MovePosition(new Vector2(cam_bottom_left.x + 0.01f, rb.position.y));
        }
        //Left Side
        if (rb.position.x < cam_bottom_left.x)
        {
            rb.MovePosition(new Vector2(cam_top_right.x + 0.01f, rb.position.y));
        }
        //Top Side
        if (rb.position.y > cam_top_right.y)
        {
            rb.MovePosition(new Vector2(cam_top_right.x, cam_bottom_left.y + 0.01f));
        }
        //Bottom Side
        if (rb.position.y < cam_bottom_left.y)
        {
            rb.MovePosition(new Vector2(cam_top_right.x, cam_top_right.y - 0.01f));
        }
        //if holding down W
        if (input_vec.y > 0)
        {
            //Move the Player Up
            rb.MovePosition(rb.position + (new Vector2(transform.up.x, transform.up.y)) * max_speed * Time.fixedDeltaTime);

            //Adding Acceleration
            velocity += new Vector2(transform.up.x, transform.up.y) * acceleration * Time.fixedDeltaTime;

            //Limit Velocity
            velocity =Vector2.ClampMagnitude(velocity, max_speed);

            //Moving the Player
            rb.MovePosition(rb.position + (velocity * Time.fixedDeltaTime));
        }

        //A or D
        if (input_vec.x != 0)
        {
            //Rotate the Player
            rb.MoveRotation(rb.rotation + (rotate_speed * Time.fixedDeltaTime));
        }

        //Moving Up
        rb.AddForce(Vector2.up, ForceMode2D.Impulse);
        rb.MovePosition(rb.position + new Vector2(transform.up.x, transform.up.y) * max_speed * Time.fixedDeltaTime);

    }
}
