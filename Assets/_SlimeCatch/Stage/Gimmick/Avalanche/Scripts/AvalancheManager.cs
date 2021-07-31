using NaughtyAttributes;
using UnityEngine;

namespace _SlimeCatch.Stage.Gimmick.Avalanche.Scripts
{
    public class AvalancheManager : MonoBehaviour
    {
        [SerializeField] private CameraShake cameraShake;

        [Button("画面を揺らす")]
        public void ShakeTest()
        {
            cameraShake.Shake();
        }
    }
}