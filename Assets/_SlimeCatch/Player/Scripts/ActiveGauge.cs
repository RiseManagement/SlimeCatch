using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveGauge : MonoBehaviour
{
    [SerializeField] _SlimeCatch.Player.SlimeExtend SlimeExtend;
    [SerializeField] Slider ActiveSlider = null;
    float ReduceValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        ReduceValue = 100;
        ValueChange(ReduceValue);
    }

    // Update is called once per frame
    void Update()
    {
        //掴んでいる時に減らす
        if (SlimeExtend._initMousePosition != SlimeExtend._CurrentMousePosition)
        {
            ReduceValue -= Time.deltaTime * 16;
        }
        else
        {
            ReduceValue += Time.deltaTime * 16;
        }
            ValueChange(ReduceValue);
    }
    void ValueChange(float CurrentValue)
    {
        ActiveSlider.value = CurrentValue;
        if (ActiveSlider.value <= 0)
        {
            SlimeExtend._GaugeEmpty = true;
        }
    }
}
