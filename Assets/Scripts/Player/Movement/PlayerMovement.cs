using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Rigidbody2D rb;

    public Slider _Slider;
    public Image Fill;
    [Space]
    [HideInInspector]public float deltaPosition;
    float jumpForce;

    public bool isGrounded = true; // Karakterin yerde olup olmad���n� kontrol etti�imiz durum

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
        if (true)
        {

        }
        if (deltaPosition >= 65)//turuncuya d�n
        {
            _Slider.value = Mathf.MoveTowards(_Slider.value, deltaPosition, 1);
            if (_Slider.value >= 65)
            {
                float r = 0;
                r = Mathf.MoveTowards(r, 250f, 1);
                Fill.color = new Color(r, 0, 0);
                jumpForce = 5;
            }
        }
        else//ye�il
        {
            //ye�il ol
            if(_Slider.value >= 35)
            jumpForce = 2.5f;
        }
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
        // Karakteri z�platmak i�in Rigidbody2D bile�enine bir kuvvet uygulay�n.
        rb.velocity = Vector2.up * jumpForce;

        // Birden fazla z�plaman�n �n�ne ge�mek i�in canJump'i false yap�n
        isGrounded = false;

    }
}
