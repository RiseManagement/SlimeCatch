using System.Collections.Generic;
using _SlimeCatch.Title;
using DG.Tweening;
using NaughtyAttributes;
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
        private const float AnimationTime = 1f;

        [Button("クリアデータ初期化")]
        private void ClearSaveData()
        {
            for (var index = 1; index <= 6; index++)
            {
                SettingPrefs.SetBool($"Stage{index}",false);
            }
        }

        [Button("全データ削除")]
        private void DeleteAll()
        {
            PlayerPrefs.DeleteAll();
        }

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _stageIconView = GetComponent<StageIconView>();
        }

        private async void Start()
        {
            _stageIconView.SetInteractable(GetStageOpenData());
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

        private static IEnumerable<bool> GetStageOpenData()
        {
            var saveList = new List<bool>();
            for (var index = 1; index <= 6; index++)
            {
                saveList.Add(SettingPrefs.IsClearStage($"Stage{index}"));
            }

            return saveList;
        }

    }
}
