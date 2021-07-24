using _SlimeCatch.Wave;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace _SlimeCatch.Stage.PopUp
{
    public class TestPopUp : MonoBehaviour
    {
        [SerializeField] private GameOverPopUp gameOverPopUp;
        [SerializeField] private GameClearPopUp gameClearPopUp;

        private void Start()
        {
            this.UpdateAsObservable().Where(_ => Input.GetKeyDown(KeyCode.C))
                .Take(1)
                .Subscribe(_ =>
                {
                    gameClearPopUp.SetView(StageEnum.Forest);
                }).AddTo(this);
            this.UpdateAsObservable()
                .Where(_=>Input.GetKeyDown(KeyCode.O))
                .Subscribe(_ =>
            {
                gameOverPopUp.SetView();
            }).AddTo(this);
        }
    }
}