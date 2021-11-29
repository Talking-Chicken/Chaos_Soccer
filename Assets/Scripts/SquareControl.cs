using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SquareControl : MonoBehaviour
{
    public float speed = 5;
    private Vector2 movementInput;
    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(new Vector2(movementInput.x, movementInput.y) * speed * Time.deltaTime);    
    }

    //public void onMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void onMove(InputAction.CallbackContext ctx) => 
        Debug.Log(ctx.ReadValue<float>());

}
