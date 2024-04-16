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
    public void ChangeColor(float DeltaPos)//Slider�n rengini ve art���n� de�i�tirmek i�in kullan�lan fonksiyon
    {
        _slider.value = Mathf.MoveTowards(_slider.value, DeltaPos, 1);//verilen g�� de�erinin daha yumu�ak bir �ekilde artmas� sa�lan�yor
        if(_slider.value >= 150)//de�er 150 den fazla ise max jump rengi
        {
            Fill.color = Color.red;
        }
        else if(_slider.value >= 65)//de�er 65 den fazla ise mid jump rengi
        {
            Fill.color = new Color(255, 162, 0);
        }
        else//de�er 65 den k���k ise low jump rengi
        {
            Fill.color = Color.green;
        }
    }
}
