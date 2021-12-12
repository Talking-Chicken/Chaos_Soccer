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

    [SerializeField] SpriteRenderer[] spriteToFlip; 

    [SerializeField] private float speed;

    [SerializeField] Rigidbody2D leftLeg1, leftLeg2, rightLeg1, rightLeg2;

    [SerializeField] GameObject dashCollider;
    private bool inDashCoolDown = false;
    private bool isDashing = false;

    public Vector2 spawnPos;

    private AudioSource audio;
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

        audio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Vector2 m1 = new Vector2(moveLeft.x, moveLeft.y);
        Vector2 m2 = new Vector2(moveRight.x, moveRight.y);

        if (dashCollider != null)
            dashCollider.transform.position = gameObject.transform.position;

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


        if (!isDashing)
        {
            //set dash collier
            dashCollider.SetActive(false);

            /*
            leftLeg1.gameObject.layer = 6;
            leftLeg2.gameObject.layer = 6;
            rightLeg1.gameObject.layer = 6;
            rightLeg2.gameObject.layer = 6;
            */

            myBody.GetComponent<SpriteRenderer>().color = Color.white;

            if (switchedLeft)
            {
                leftLeg1.constraints = RigidbodyConstraints2D.None;
                leftLeg1.velocity = m1 * speed;
                leftLeg2.constraints = RigidbodyConstraints2D.FreezePosition;
                leftLeg1.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                leftLeg2.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

                rightLeg1.constraints = RigidbodyConstraints2D.None;
                rightLeg1.velocity = m1 * speed;
                rightLeg2.constraints = RigidbodyConstraints2D.FreezePosition;
                rightLeg1.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                rightLeg2.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

                if (leftLeg1.velocity.normalized.x < 0.5)
                    foreach (SpriteRenderer sr in spriteToFlip)
                        sr.flipX = false;
                else
                    foreach (SpriteRenderer sr in spriteToFlip)
                        sr.flipX = true;
            }
            else if (switchedRight)
            {
                leftLeg2.constraints = RigidbodyConstraints2D.None;
                leftLeg2.velocity = m1 * speed;
                leftLeg1.constraints = RigidbodyConstraints2D.FreezePosition;
                leftLeg2.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                leftLeg1.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

                rightLeg2.constraints = RigidbodyConstraints2D.None;
                rightLeg2.velocity = m1 * speed;
                rightLeg1.constraints = RigidbodyConstraints2D.FreezePosition;
                rightLeg2.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                rightLeg1.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

                if (rightLeg2.velocity.normalized.x < 0.5)
                    foreach (SpriteRenderer sr in spriteToFlip)
                        sr.flipX = false;
                else
                    foreach (SpriteRenderer sr in spriteToFlip)
                        sr.flipX = true;
            }
            else
            {
                leftLeg1.constraints = RigidbodyConstraints2D.FreezePosition;
                leftLeg2.constraints = RigidbodyConstraints2D.FreezePosition;
                rightLeg1.constraints = RigidbodyConstraints2D.FreezePosition;
                rightLeg2.constraints = RigidbodyConstraints2D.FreezePosition;
                rightLeg1.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                rightLeg2.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                leftLeg1.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                leftLeg2.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        } else
        {
            dashCollider.SetActive(true);
            Vector2 direction;
            direction = myBody.velocity;


            leftLeg1.constraints = RigidbodyConstraints2D.None;
            leftLeg2.constraints = RigidbodyConstraints2D.None;
            rightLeg1.constraints = RigidbodyConstraints2D.None;
            rightLeg2.constraints = RigidbodyConstraints2D.None;

            //set all legs to not collide with bumper when dash
            /*
            leftLeg1.gameObject.layer = 8;
            leftLeg2.gameObject.layer = 8;
            rightLeg1.gameObject.layer = 8;
            rightLeg2.gameObject.layer = 8;
            */

            myBody.GetComponent<SpriteRenderer>().color = Color.red;

            transform.position += new Vector3(direction.x, direction.y, 0) * 0.04f;
            
        }
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
    
    public void dash()
    {
        if (!inDashCoolDown)
        {
            inDashCoolDown = true;
            isDashing = true;
            StartCoroutine(dashCooldown());
            StartCoroutine(dashing());
        }
    }

    IEnumerator dashCooldown()
    {
        yield return new WaitForSeconds(3.0f);
        inDashCoolDown = false;
    }

    IEnumerator dashing()
    {
        audio.Play();
        yield return new WaitForSeconds(0.4f);
        isDashing = false;
    }

}
