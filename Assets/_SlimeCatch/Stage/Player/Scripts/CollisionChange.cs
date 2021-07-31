using UnityEngine;

namespace _SlimeCatch.Player
{
    
    public class CollisionChange : MonoBehaviour
    {
        private SlimeExtend _slimeExtend;

        private void Awake()
        {
            _slimeExtend = GetComponent<SlimeExtend>();
        }

        // Update is called once per frame
        private void Update()
        {
            //掴んでいる時に減らす
            gameObject.layer = LayerMask.NameToLayer(_slimeExtend._initMousePosition != _slimeExtend._CurrentMousePosition ? "Default" : "CollisionOff");
        }
    }
}
