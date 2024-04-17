using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IDamageable
{
    public SliderColorChange sliderColorChange;
    public HPManager HpManager;
    private Vector2 startTouchPosition;
    private Rigidbody2D rb;
    private Animator animator;

    [HideInInspector]
    public float deltaPosition;
    float jumpForce;
    public int Health = 3;
    [Space]
    public bool isGrounded = true; // Karakterin yerde olup olmad���n� kontrol etti�imiz durum

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;//ilk dokundu�umuz noktay� alan kod
            }

            if (touch.phase == TouchPhase.Ended && isGrounded)
            {
                deltaPosition = (touch.position.y - startTouchPosition.y)/10;//kayd�rma miktar�m�z� alan kod
                Debug.Log(deltaPosition);
                Jump();
            }
        }
        if (!isGrounded)
        {
            sliderColorChange.ChangeColor(deltaPosition);
            CheckYPos();
        }

        animator.SetBool("isGrounded", isGrounded);

    }

    void Jump()
    {
        if (deltaPosition >= 150)
        {
            jumpForce = 15;

        }
        else if(deltaPosition >= 65)
        {
            jumpForce = 10f;
        }
        else
        {
            jumpForce = 7f;
        }
        // Karakteri z�platmak i�in Rigidbody2D bile�enine bir kuvvet uygulay�n.
        rb.velocity = Vector2.up * jumpForce;

        // Birden fazla z�plaman�n �n�ne ge�mek i�in canJump'i false yap�n
        isGrounded = false;

    }
    void CheckYPos()
    {
        if(rb.velocity.y >= 0)
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }
    }

    public void TakeDamage()
    {
        animator.SetTrigger("Hurth");
        Health -= 1;
        HpManager.HearthsClose();
        if(Health == 0)
        {
            Time.timeScale = 0f;
            Debug.Log("Karakter �ld�");
        }
    }
}
