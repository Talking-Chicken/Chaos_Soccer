using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Athelete : MonoBehaviour
{
    PlayerControls control;

    Vector2 moveLeft, moveRight;
    bool switchedLeft, switchedRight;

    Rigidbody2D myBody;

    [SerializeField] private float speed;

    [SerializeField] Rigidbody2D leftLeg1, leftLeg2, rightLeg1, rightLeg2;

    public Vector2 spawnPos;
    private void Awake()
    {
      /**  
        control = new PlayerControls();

        control.Gameplay.MoveLeft.performed += ctx => moveLeft = ctx.ReadValue<Vector2>();
        control.Gameplay.MoveLeft.canceled += ctx => moveLeft = Vector2.zero;

        control.Gameplay.MoveRight.performed += ctx => moveRight = ctx.ReadValue<Vector2>();
        control.Gameplay.MoveRight.canceled += ctx => moveLeft = Vector2.zero;

        control.Gameplay.SwitchLeft.performed += ctx => switchedLeft = true;
        control.Gameplay.SwitchLeft.canceled += ctx => switchedLeft = false;

        control.Gameplay.SwitchRight.performed += ctx => switchedRight = true;
        control.Gameplay.SwitchRight.canceled += ctx => switchedRight = false;
      */
        

        if (GetComponent<Rigidbody2D>() != null)
            myBody = GetComponent<Rigidbody2D>();
        else
            Debug.LogWarning("can't detect rigid body 2d in " + name);
    }

    private void FixedUpdate()
    {
        Vector2 m1 = new Vector2(moveLeft.x, moveLeft.y);
        Vector2 m2 = new Vector2(moveRight.x, moveRight.y);

        if (moveLeft == Vector2.zero)
        {
            leftLeg1.constraints = RigidbodyConstraints2D.FreezePosition;
            leftLeg2.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        if (moveRight == Vector2.zero)
        {
            rightLeg1.constraints = RigidbodyConstraints2D.FreezePosition;
            rightLeg2.constraints = RigidbodyConstraints2D.FreezePosition;
        }

        if (!switchedLeft)
        {
            leftLeg1.constraints = RigidbodyConstraints2D.None;
            leftLeg1.velocity = m1 * speed;
            leftLeg2.constraints = RigidbodyConstraints2D.FreezePosition;
            leftLeg1.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            leftLeg2.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            leftLeg2.constraints = RigidbodyConstraints2D.None;
            leftLeg2.velocity = m1 * speed;
            leftLeg1.constraints = RigidbodyConstraints2D.FreezePosition;
            leftLeg2.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            leftLeg1.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (!switchedRight)
        {
            rightLeg1.constraints = RigidbodyConstraints2D.None;
            rightLeg1.velocity = m1 * speed;
            rightLeg2.constraints = RigidbodyConstraints2D.FreezePosition;
            rightLeg1.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            rightLeg2.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            rightLeg2.constraints = RigidbodyConstraints2D.None;
            rightLeg2.velocity = m1 * speed;
            rightLeg1.constraints = RigidbodyConstraints2D.FreezePosition;
            rightLeg2.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            rightLeg1.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void OnEnable()
    {
        //control.Gameplay.Enable();
    }

    
    public void onMoveLeft(InputAction.CallbackContext ctx) => moveLeft = ctx.ReadValue<Vector2>();
    public void onMoveRight(InputAction.CallbackContext ctx) => moveRight = ctx.ReadValue<Vector2>();
    public void onSwitchLeft(InputAction.CallbackContext ctx) => switchedLeft = checkHold(ctx.ReadValue<float>());
    public void onSwitchRight(InputAction.CallbackContext ctx) => switchedRight = checkHold(ctx.ReadValue<float>());

    public void flip(InputAction.CallbackContext ctx) => flipX(GetComponentInParent<Transform>());

    public bool checkHold(float value)
    {
        if (value > 0.5)
            return true;
        else
            return false;
    }

    public void flipX(Transform t)
    {
        t.localScale = new Vector2(t.localScale.x * -1, 1);
    }
    
}
