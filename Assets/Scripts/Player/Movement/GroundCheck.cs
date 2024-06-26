using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    Player playerMain;
    public SliderColorChange SliderColor;
    private void Start()
    {
        playerMain = GetComponentInParent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            playerMain.isGrounded = true;
            playerMain.deltaPosition = 0;
            SliderColor.Fill.color = Color.green;
            SliderColor._slider.value = 0;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            playerMain.isGrounded = true;
        }
    }
}
