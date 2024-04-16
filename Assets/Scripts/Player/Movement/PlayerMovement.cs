using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public SliderColorChange sliderColorChange;

    private Vector2 startTouchPosition;
    private Rigidbody2D rb;

    [HideInInspector]
    public float deltaPosition;
    float jumpForce;

    public bool isGrounded = true; // Karakterin yerde olup olmadýðýný kontrol ettiðimiz durum

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended && isGrounded)
            {
                deltaPosition = (touch.position.y - startTouchPosition.y)/10;
                Debug.Log(deltaPosition);
                Jump();
            }
        }
        if(!isGrounded)
            sliderColorChange.ChangeColor(deltaPosition);

    }

    void Jump()
    {
        if (deltaPosition >= 150)
        {
            jumpForce = 7;

        }
        else if(deltaPosition >= 65)
        {
            jumpForce = 5;
        }
        else
        {
            jumpForce = 2.5f;
        }
        // Karakteri zýplatmak için Rigidbody2D bileþenine bir kuvvet uygulayýn.
        rb.velocity = Vector2.up * jumpForce;

        // Birden fazla zýplamanýn önüne geçmek için canJump'i false yapýn
        isGrounded = false;

    }
}
