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
            this.UpdateAsObservable().Subscribe(_ =>
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    gameClearPopUp.SetView(StageEnum.Forest);
                }else if (Input.GetKeyDown(KeyCode.O))
                {
                    gameOverPopUp.SetView();
                }
            }).AddTo(this);
        }
    }
}