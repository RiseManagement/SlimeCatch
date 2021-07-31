using UnityEngine;

namespace _SlimeCatch.Player
{
    public class AngleRotation : MonoBehaviour
    {
        public void UpdateSlimeRotation(Vector3 inputPosition,Transform playerTransform)
        {
            var pd = inputPosition - playerTransform.position; 
            var pn = pd.normalized;

            pn = new Vector3(pn.x, pn.y, 0).normalized;
            if (!(0f < pn.y)) return;
            var angle = Vector3.Angle(new Vector3(0, 1, 0), pn);
            if (pn.x > 0) angle = -angle;
            var rotation = playerTransform.rotation;
            rotation = Quaternion.Euler(rotation.x, rotation.y, angle);
            transform.rotation = rotation;

        }
    }
}
