using System;
using System.Collections.Generic;
using System.Linq;
using _SlimeCatch.Wave;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _SlimeCatch.Stage.PopUp
{
    public class GameClearPopUp : MonoBehaviour
    {
        [SerializeField] private List<StageInfo> stageInfoList;
        [SerializeField] private Image nextStageImage;
        [SerializeField] private Text nextStageText;
        [SerializeField] private AudioClip gameClearSe;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public async void SetView(StageEnum stageEnum)
        {
            gameObject.SetActive(true);
            _audioSource.PlayOneShot(gameClearSe);
            if (!_SlimeCatch.SelectStage.AnimationManager.playFlg)
            {
                SetNextStageInfo(stageEnum);
            }
            //SetNextStageInfo(stageEnum);
            PlayerPrefs.SetString("SceneName", SceneManager.GetActiveScene().name);
            //todo シーン遷移の時間を調節する
            await UniTask.Delay(TimeSpan.FromSeconds(3f));
            SceneManager.LoadSceneAsync("_SlimeCatch/SelectStage/SelectStage");
        }

        private void SetNextStageInfo(StageEnum stageEnum)
        {
            foreach (var stageInfo in stageInfoList.Where(stageInfo => stageInfo.stageName == stageEnum.Next()))
            {
                nextStageImage.sprite = stageInfo.backGroundImage;
                nextStageText.text = $"{stageEnum.Next()}ステージ解放";
            }
        }
    }

    [Serializable]
    class StageInfo
    {
        public Sprite backGroundImage;
        public StageEnum stageName;
    }
}