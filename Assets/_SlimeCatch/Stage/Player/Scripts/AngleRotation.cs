using UnityEngine;

namespace _SlimeCatch.Player
{
    public class AngleRotation : MonoBehaviour
    {
        private void Update()
        {
            if (!Input.GetMouseButton(0)) return;
            var pd = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position; 
            var pn = pd.normalized; 

            pn = new Vector3(pn.x, pn.y, 0); 
                
            var angle = Vector3.Angle(new Vector3(0, 1, 0), pn);
            if (pn.x > 0) angle = -angle;
            var rotation = transform.rotation;
            rotation = Quaternion.Euler(rotation.x, rotation.y, angle);
            transform.rotation = rotation;
        }
    }
}
