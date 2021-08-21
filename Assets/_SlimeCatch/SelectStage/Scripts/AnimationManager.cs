using BayatGames.SaveGameFree;
using DG.Tweening;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace _SlimeCatch.SelectStage
{
    public class AnimationManager : MonoBehaviour
    {
        //アイコンオブジェクト格納（座標取得用）
        public GameObject iconOne;
        public GameObject iconTwo;
        public GameObject iconThree;
        public GameObject iconFour;
        public GameObject iconFive;
        public GameObject iconSix;

        private string stageName; //前シーンのステージ名
        private int stageNumber; //前シーンのステージ名から抽出した数字
        public static bool playFlg; //アニメーションを再生したかの判別
        public GameObject openAnimeImage; //アニメーション用画像
        void Start()
        {
            stageName = PlayerPrefs.GetString("SceneName", ""); //クリアしたステージ名をPlayerPrefsから取得
            if (stageName == "Title" || stageName == "")
            {
                stageName = "none";
            }
            else
            {
                stageNumber = int.Parse(Regex.Replace(stageName, @"[^0-9]", "")); //ステージ名から数字を抽出
                //クリアフラグ呼び出し第一引数のキー登録が無ければ第二引数が返る
                playFlg = SettingPrefs.GetBool($"{stageName}", false);
                //openAnimeImage.SetActive(false);
                AnimePlay();
            }
        }
        void AnimePlay()
        {
            if (!playFlg)
            {
                if (stageName == "Stage1")
                {
                    openAnimeImage.transform.position = iconTwo.transform.position;
                }
                if (stageName == "Stage2")
                {
                    openAnimeImage.transform.position = iconThree.transform.position;
                }
                if (stageName == "Stage3")
                {
                    openAnimeImage.transform.position = iconFour.transform.position;
                }
                if (stageName == "Stage4")
                {
                    openAnimeImage.transform.position = iconFive.transform.position;
                }
                if (stageName == "Stage5")
                {
                    openAnimeImage.transform.position = iconSix.transform.position;
                }

                openAnimeImage.SetActive(true);
                //アニメーション
                var sizeSequence = DOTween.Sequence();
                sizeSequence.Append(
                    openAnimeImage.transform.DOMoveY(openAnimeImage.transform.position.y + 100, 3f)
                    );
                sizeSequence.Join(
                    openAnimeImage.transform.DOScale(new Vector3(1f, 1f), 3f)
                    );

                var alphaSequence = DOTween.Sequence();
                var image = openAnimeImage.GetComponent<Image>();
                alphaSequence.Append(
                    DOTween.ToAlpha(
                        () => image.color,
                        color => image.color = color,
                        1f,
                        5f
                        )
                    );
                alphaSequence.Append(
                    DOTween.ToAlpha(
                        () => image.color,
                        color => image.color = color,
                        0f,
                        1f
                        )
                    );
                //アニメーションここまで
                SettingPrefs.SetBool($"{stageName}", true);
            }
        }
    }
}
