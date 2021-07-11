using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1.UIシステムを使うときに必要なライブラリ
using UnityEngine.UI;
// 2.Scene関係の処理を行うときに必要なライブラリ
using UnityEngine.SceneManagement;

public class SelectStageManager : MonoBehaviour
{
    public void SelectStage1()
    {
        SceneManager.LoadSceneAsync("Stage1");
    }

    public void SelectStage2()
    {
        SceneManager.LoadSceneAsync("Stage2");
    }

    public void SelectStage3()
    {
        SceneManager.LoadSceneAsync("Stage3");
    }

    public void SelectStage4()
    {
        SceneManager.LoadSceneAsync("Stage4");
    }

    public void SelectStage5()
    {
        SceneManager.LoadSceneAsync("Stage5");
    }

    public void SelectStage6()
    {
        SceneManager.LoadSceneAsync("Stage6");
    }

}