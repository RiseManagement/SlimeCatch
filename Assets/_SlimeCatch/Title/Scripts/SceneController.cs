using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _SlimeCatch.Title
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private Button gameStartButton;
        private CanvasGroup _canvasGroup;

        private const float FadeOutTime = 1f;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            gameStartButton.OnClickAsObservable()
                .Take(1)
                .Subscribe(async _ =>
                {
                    await _canvasGroup.DOFade(0f, FadeOutTime).ToAwaiter();
                    SceneManager.LoadSceneAsync("SelectStage");
                }).AddTo(this);
        }
    }
}