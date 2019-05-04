using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceDisplaySlider : MonoBehaviour
{
    public bool visible = false;
    public float pressedTime = 0;

    Slider TimeSlider;

    // Start is called before the first frame update
    void Start()
    {
        TimeSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeSlider.value = pressedTime;
    }
}
