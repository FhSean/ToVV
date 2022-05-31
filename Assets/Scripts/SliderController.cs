using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = this.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = Input.GetAxis("HorizontalButton");
        slider.value = slider.value + step * 0.03f;
    }
}
