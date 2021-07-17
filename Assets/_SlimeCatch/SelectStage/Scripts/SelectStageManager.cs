using System;
using _SlimeCatch.Save;
using _SlimeCatch.Title;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _SlimeCatch.SelectStage
{
    
    public class SelectStageManager : MonoBehaviour
    {
        private bool _isInput;
        [SerializeField] private AudioController audioController; 
        private StageIconView _stageIconView;
        private ILoadController _loadController;

        private void Awake()
        {
            _loadController = new SaveLoadController();
            _stageIconView = GetComponent<StageIconView>();

        }

        private async void Start()
        {
            _stageIconView.SetInteractable(_loadController.GetStageClearList());
            await UniTask.Delay(TimeSpan.FromSeconds(2f));
            _isInput = true;
        }

        public void SelectStage1()
        {
            if (_isInput)
            {
                audioController.ClickOnPlaySe();
                SceneManager.LoadSceneAsync("Stage1");
            }
        }

        public void SelectStage2()
        {
            if (_isInput)
            {
                audioController.ClickOnPlaySe();
                SceneManager.LoadSceneAsync("Stage2");
            }
        }

        public void SelectStage3()
        {
            if (_isInput)
            {
                audioController.ClickOnPlaySe();
                SceneManager.LoadSceneAsync("Stage3");
            }
        }

        public void SelectStage4()
        {
            if (_isInput)
            {
                audioController.ClickOnPlaySe();
                SceneManager.LoadSceneAsync("Stage4");
            }
        }

        public void SelectStage5()
        {
            if (_isInput)
            {
                audioController.ClickOnPlaySe();
                SceneManager.LoadSceneAsync("Stage5");
            }
        }

        public void SelectStage6()
        {
            if (_isInput)
            {
                audioController.ClickOnPlaySe();
                SceneManager.LoadSceneAsync("Stage6");
            }
        }

    }
}
