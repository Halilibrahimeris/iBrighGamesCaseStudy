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
    public void ChangeColor(float DeltaPos)//Sliderýn rengini ve artýþýný deðiþtirmek için kullanýlan fonksiyon
    {
        _slider.value = Mathf.MoveTowards(_slider.value, DeltaPos, 1);//verilen güç deðerinin daha yumuþak bir þekilde artmasý saðlanýyor
        if(_slider.value >= 150)//deðer 150 den fazla ise max jump rengi
        {
            Fill.color = Color.red;
        }
        else if(_slider.value >= 65)//deðer 65 den fazla ise mid jump rengi
        {
            Fill.color = new Color(255, 162, 0);
        }
        else//deðer 65 den küçük ise low jump rengi
        {
            Fill.color = Color.green;
        }
    }
}
