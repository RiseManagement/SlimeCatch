using _SlimeCatch.Save;
using _SlimeCatch.Title;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _SlimeCatch.SelectStage
{
    
    public class SelectStageManager : MonoBehaviour
    {
        private bool _isInput;
        [SerializeField] private AudioController audioController; 
        private StageIconView _stageIconView;
        private CanvasGroup _canvasGroup;
        private ILoadController _loadController;
        private const float AnimationTime = 1f;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _loadController = new SaveLoadController();
            _stageIconView = GetComponent<StageIconView>();

        }

        private async void Start()
        {
            _stageIconView.SetInteractable(_loadController.GetStageClearList());
            await _canvasGroup.DOFade(1f,AnimationTime).ToAwaiter();
            _isInput = true;
        }

        public void SelectStage1()
        {
            if (_isInput)
            {
                ChangeToStage(1);
            }
        }

        public void SelectStage2()
        {
            if (_isInput)
            {
                ChangeToStage(2);
            }
        }

        public void SelectStage3()
        {
            if (_isInput)
            {
                ChangeToStage(3);
            }
        }

        public void SelectStage4()
        {
            if (_isInput)
            {
                ChangeToStage(4);
            }
        }

        public void SelectStage5()
        {
            if (_isInput)
            {
                ChangeToStage(5);
            }
        }

        public void SelectStage6()
        {
            if (_isInput)
            {
                ChangeToStage(6);
            }
        }

        private async void ChangeToStage(int stageNo)
        {
            audioController.ClickOnPlaySe();
            await _canvasGroup.DOFade(0f,AnimationTime).ToAwaiter();
            SceneManager.LoadSceneAsync($"stage{stageNo}");
        }

    }
}
