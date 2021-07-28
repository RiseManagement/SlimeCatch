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

        private async void Start()
        {
            await IsGameClear();
        }

        private async UniTask IsGameClear()
        {
            await UniTask.WaitUntil(() => waveController.endWave);
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            gameClearPopUp.SetView(waveController.GetStageEnum());
        }
    }
}