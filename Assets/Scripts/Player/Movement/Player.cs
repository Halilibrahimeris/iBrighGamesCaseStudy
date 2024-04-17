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
    public bool isGrounded = true; // Karakterin yerde olup olmadýðýný kontrol ettiðimiz durum

    [Space]
    public GameObject EndGameScreen;

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
                startTouchPosition = touch.position;//ilk dokunduðumuz noktayý alan kod
            }

            if (touch.phase == TouchPhase.Ended && isGrounded)
            {
                deltaPosition = (touch.position.y - startTouchPosition.y)/10;//kaydýrma miktarýmýzý alan kod
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
        // Karakteri zýplatmak için Rigidbody'e yukarý doðru güç uyguluyorum
        rb.velocity = Vector2.up * jumpForce;

        // Birden fazla zýplamanýn önüne geçmek için isGrounded deðiþkenini kullanýyorum
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
            EndGameScreen.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Karakter öldü");
        }
    }
}
