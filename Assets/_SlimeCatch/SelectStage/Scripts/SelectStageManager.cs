using System;
using _SlimeCatch.Title;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStageManager : MonoBehaviour
{
    private bool _isInput;
    [SerializeField] private AudioController audioController;

    private async void Start()
    {
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
