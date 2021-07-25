using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace _SlimeCatch.Stage.Gimmick
{
    public class ViewFlash : MonoBehaviour
    {
        private Image _flashImage;
        private void Awake()
        {
            _flashImage = GetComponent<Image>();
            _flashImage.color = Color.clear;
        }

        private void Start()
        {
            //todo デバッグ用
            this.UpdateAsObservable().Where(_ => Input.GetKeyDown(KeyCode.Alpha9))
                .Subscribe(_ =>
                {
                    SetFlash();
                }).AddTo(this);
        }

        public void SetFlash()
        {
            _flashImage.color = new Color(1, 1, 1, 1);
        }

        private void Update()
        {
            _flashImage.color = Color.Lerp(_flashImage.color, Color.clear, Time.deltaTime);
        }
    }
}