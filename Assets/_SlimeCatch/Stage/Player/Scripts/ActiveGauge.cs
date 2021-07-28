using UnityEngine;
using UnityEngine.UI;

namespace _SlimeCatch.Player
{
    
    public class ActiveGauge : MonoBehaviour
    {
        [SerializeField] private SlimeExtend slimeExtend;
        [SerializeField] private Slider ActiveSlider = null;

        private float _reduceValue = 0;

        private void Start()
        {
            _reduceValue = 5;
            ValueChange(_reduceValue);
        }

        // Update is called once per frame
        private void Update()
        {
            //掴んでいる時に減らす
            if (slimeExtend._initMousePosition != slimeExtend._CurrentMousePosition)
            {
                _reduceValue -= Time.deltaTime;
            }
            else
            {
                _reduceValue += Time.deltaTime;
            }

            ValueChange(_reduceValue);
        }

        private void ValueChange(float CurrentValue)
        {
            ActiveSlider.value = CurrentValue;
            if (ActiveSlider.value <= 0)
            {
                slimeExtend._GaugeEmpty = true;
            }
        }
    }
}
