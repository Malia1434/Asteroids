using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{

    //Components
    private Rigidbody2D rb;

    //Movement
    private Vector2 direction = Vector2.zero;
    private float max_speed = 0;
    private Vector2 velocity = Vector2.zero;

    //Graphics
    public GameObject asteroid_sprite;
    public Sprite[] array_of_sprites;
    private float spin_speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Give Asteroids a random speed.
        max_speed = Random.Range(0.65f, 1.1f);

        //picking a starting angle for the steroid to move in.
        float start_angle = Random.Range(0, 360);
        start_angle *= Mathf.Deg2Rad;
        direction.x = Mathf.Cos(start_angle);
        direction.y = Mathf.Sin(start_angle);

        //Calculate the velocity.
        velocity = direction * max_speed;

        //Set the Sprite of the Asteroid to a random sprite.
        asteroids_sprite.GetCompontent<SpriteRenderer>().sprite = array_of_sprites[Random.Range(0, array_of_sprites.Length)];

        //Set spin_speed.
        spin_speed = Random.Range(-20f, 20f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move the asteroid.
        rb.MovePosition(rb.position + (velocity * Time.fixedDeltaTime));
    }


    void Update()
    {
     asteroids_sprite.transform.Rotate(Vector3.forward, spin_speed *  Time.fixedDeltaTime);   
    }
}
