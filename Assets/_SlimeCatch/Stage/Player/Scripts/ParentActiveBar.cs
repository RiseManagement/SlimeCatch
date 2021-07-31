using UnityEngine;
using UnityEngine.UI;

namespace _SlimeCatch.Player
{
    public class ParentActiveBar : MonoBehaviour
    {
        [SerializeField] private Slider activeSlider;
        public void SetActiveValue(float value)
        {
            activeSlider.value = value;
        }
    }
}
