using UnityEngine;

namespace _SlimeCatch.Player
{
    public class CollisionChange : MonoBehaviour
    {
        public void ChangeLayer(bool slimeExtend)
        {
            gameObject.layer = LayerMask.NameToLayer(slimeExtend ? "Default" : "CollisionOff");
        }

    }
}
