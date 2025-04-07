using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //Player Input
    private Vector2 input_vec = Vector2.zero;

    public void CaptureMoveInput (InputAction.CallbackContext context)
    {
        input_vec = context.ReadValue<Vector2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(input_vec);
    }
}
