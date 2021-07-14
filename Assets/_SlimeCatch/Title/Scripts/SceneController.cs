using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace _SlimeCatch.Title
{
    public class SceneController : MonoBehaviour
    {
        private void Start()
        {
            this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0))
                .Take(1)
                .Subscribe(_ =>
                {
                    UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("SelectStage");
                }).AddTo(this);
        }
    }
}