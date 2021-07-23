using System;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace _SlimeCatch.SelectStage
{
    public class ConnectStageAnimation : MonoBehaviour
    {
        [SerializeField] private List<Image> nextStageImage;
        [SerializeField] private float connectFadeAnimation = 2f;


        private void Start()
        {
            //todo デバッグ用
            this.UpdateAsObservable().Where(_ => Input.GetKeyDown(KeyCode.Alpha6))
                .Subscribe(_ =>
                {
                    SetAnimation(0);
                }).AddTo(this);
        }

        public void SetAnimation(int nextStageNo)
        {
            nextStageImage[nextStageNo].DOFillAmount(1f, connectFadeAnimation);
        }
    }
}