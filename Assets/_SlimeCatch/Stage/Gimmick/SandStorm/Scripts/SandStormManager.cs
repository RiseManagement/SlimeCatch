using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;

namespace _SlimeCatch.Stage.Gimmick.SandStorm.Scripts
{
    public class SandStormManager : MonoBehaviour
    {
        [FormerlySerializedAs("SandStorm")] [SerializeField] private ParticleSystem sandStorm;

        private void Awake()
        {
            sandStorm.Stop();
        }
        void Start()
        {
            Observable.Interval(TimeSpan.FromSeconds(20))
                .Subscribe(async x =>
                    {
                        sandStorm.Play();
                        await UniTask.Delay(TimeSpan.FromSeconds(5f));
                        sandStorm.Stop();
                    }
                ).AddTo(this);
        }
    }
}