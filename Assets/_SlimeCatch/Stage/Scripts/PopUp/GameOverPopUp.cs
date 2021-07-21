using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _SlimeCatch.Stage.PopUp
{
    public class GameOverPopUp : MonoBehaviour
    {
        [SerializeField] private Button retryButton;
        [SerializeField] private Button backStageSelectButton;

        private void Start()
        {
            retryButton.OnClickAsObservable().Subscribe(_ =>
            {
                gameObject.SetActive(false);
            }).AddTo(this);

            backStageSelectButton.OnClickAsObservable().Subscribe(_ =>
            {
                gameObject.SetActive(false);
                SceneManager.LoadSceneAsync("_SlimeCatch/SelectStage/SelectStage");
            }).AddTo(this);
        }

        public void SetView()
        {
            gameObject.SetActive(true);
        }
    }
}