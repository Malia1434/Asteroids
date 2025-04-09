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

    public void CaptureMoveInput (InputAction.CallbackContext context)
    {
        input_vec = context.ReadValue<Vector2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(input_vec);

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
