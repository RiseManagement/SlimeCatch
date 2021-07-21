using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _SlimeCatch.Stage.PopUp
{
    public class GameOverController : MonoBehaviour
    {
        [SerializeField] private Button retryButton;
        [SerializeField] private Button backStageSelectButton;

        private void Start()
        {
            retryButton.OnClickAsObservable().Subscribe(_ =>
            {
                Debug.Log("retry");
                gameObject.SetActive(false);
            }).AddTo(this);

            backStageSelectButton.OnClickAsObservable().Subscribe(_ =>
            {
                Debug.Log("back stage");
                SceneManager.LoadSceneAsync("_SlimeCatch/SelectStage/SelectStage");
            }).AddTo(this);
        }
    }
}