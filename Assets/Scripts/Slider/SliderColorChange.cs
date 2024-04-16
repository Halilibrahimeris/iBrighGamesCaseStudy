using UnityEngine;
using UnityEngine.UI;

public class SliderColorChange : MonoBehaviour
{
    [HideInInspector]public Slider _slider;
    public Image Fill;


    private void Start()
    {
        _slider = GetComponent<Slider>();
    }
    public void ChangeColor(float DeltaPos)
    {
        _slider.value = Mathf.MoveTowards(_slider.value, DeltaPos, 1);
        if(_slider.value >= 150)
        {
            Fill.color = Color.red;
        }
        else if(_slider.value >= 65)
        {
            Fill.color = new Color(255, 162, 0);
        }
        else
        {
            Fill.color = Color.green;
        }
    }
}
