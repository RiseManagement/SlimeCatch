using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1.UI�V�X�e�����g���Ƃ��ɕK�v�ȃ��C�u����
using UnityEngine.UI;
// 2.Scene�֌W�̏������s���Ƃ��ɕK�v�ȃ��C�u����
using UnityEngine.SceneManagement;

public class stage4scenetransition : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 3.OnRetry�֐������s���ꂽ��Ascene��ǂݍ���
    public void OnRetry()
    {
        // �uButtonScene�v�������̓ǂݍ��݂���scene���ɕς���
        SceneManager.LoadScene("Stage4");
    }
}