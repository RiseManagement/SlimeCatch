using System;
using Cysharp.Threading.Tasks;
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

        [SerializeField] private AudioClip retryButtonSe;
        [SerializeField] private AudioClip toStageSelectButtonSe;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            retryButton.OnClickAsObservable().Subscribe(_ =>
            {
                _audioSource.PlayOneShot(retryButtonSe);
                gameObject.SetActive(false);
            }).AddTo(this);

            backStageSelectButton.OnClickAsObservable().Subscribe(async _ =>
            {
                _audioSource.PlayOneShot(toStageSelectButtonSe);
                //Seの音が聞こえるように時間調節 -> todo SEがなり終わったら遷移にしたほうがいい
                await UniTask.Delay(TimeSpan.FromMilliseconds(200f));
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