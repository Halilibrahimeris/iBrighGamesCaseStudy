using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    PlayerMovement playerMain;
    private void Start()
    {
        playerMain = GetComponentInParent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            playerMain.isGrounded = true;
            playerMain.Fill.color = Color.green;
            playerMain._Slider.value = 0;
            playerMain.deltaPosition = 0;
        }
    }
}
