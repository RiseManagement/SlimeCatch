using System;
using _SlimeCatch.Stage.PopUp;
using _SlimeCatch.Wave;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _SlimeCatch.Stage
{
    public class GameStageManager : MonoBehaviour
    {
        [SerializeField] private GameClearPopUp gameClearPopUp;
        [SerializeField] private GameOverPopUp gameOverPopUp;
        [SerializeField] private WaveController waveController;
        private ChildSlimeList _childSlimeList;

        private void Awake()
        {
            _childSlimeList = GetComponent<ChildSlimeList>();
        }

        private void Start()
        {
            IsGameOver();
            IsGameClear();
        }

        private async void IsGameClear()
        {
            await UniTask.WaitUntil(() => waveController.endWave);
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            gameClearPopUp.SetView(waveController.GetStageEnum());
        }

        private async void IsGameOver()
        {
            await UniTask.WaitUntil(() => _childSlimeList.GetAliveSlimeChildCount == 0);
            gameOverPopUp.SetView();
        }
    }
}