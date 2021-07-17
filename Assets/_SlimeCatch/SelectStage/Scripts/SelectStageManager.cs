using _SlimeCatch.Title;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStageManager : MonoBehaviour
{
    private bool _isInput;
    [SerializeField] private AudioController audioController;
    private CanvasGroup _canvasGroup;
    private const float FadeInTime = 1f;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private async void Start()
    {
        await _canvasGroup.DOFade(1, FadeInTime).ToAwaiter();
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
