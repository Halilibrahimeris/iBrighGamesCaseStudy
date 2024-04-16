using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    PlayerMovement playerMain;
    public SliderColorChange SliderColor;
    private void Start()
    {
        playerMain = GetComponentInParent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            playerMain.isGrounded = true;
            playerMain.deltaPosition = 0;
            SliderColor.Fill.color = Color.green;
            SliderColor.r = 0; SliderColor.g = 255; SliderColor.b = 0;
            SliderColor._slider.value = 0;
        }
    }
}
