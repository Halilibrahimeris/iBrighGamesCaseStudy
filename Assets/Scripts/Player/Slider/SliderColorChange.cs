using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderColorChange : MonoBehaviour
{
    [HideInInspector]public Slider _slider;
    public Image Fill;
    [Space]
    public float SliderSpeed;
    [Space]
    public float r = 0;
    public float g = 0;
    public float b = 0;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }
    public void ChangeColor(float DeltaPos)
    {
        _slider.value = Mathf.MoveTowards(_slider.value, DeltaPos, 1);
        if(_slider.value >= 65)
        {
            r = Mathf.Lerp(r, 250f, Time.deltaTime * SliderSpeed);
            Fill.color = new Color(r, 0, 0);
        }
        else
        {
            //r = 255
            //g = 162
            r = Mathf.Lerp(r, 255, Time.deltaTime * SliderSpeed);
            g = Mathf.Lerp(g, 162, Time.deltaTime * SliderSpeed);
            Fill.color = new Color(r, g, 0);
        }
    }
}
