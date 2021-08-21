using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            if (!SelectStage.AnimationManager.playFlg)
            {
                SetNextStageInfo(stageEnum);
            }
            PlayerPrefs.SetString("SceneName", SceneManager.GetActiveScene().name);
            var stageNumber = int.Parse(Regex.Replace(SceneManager.GetActiveScene().name, @"[^0-9]", ""));
            var nextStageIndex = stageNumber + 1;
            SettingPrefs.SetBool($"Stage{nextStageIndex}",true);
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