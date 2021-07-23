using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace _SlimeCatch.Stage
{
    public class StartFadeIn : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer player;
        [SerializeField] private SpriteRenderer backGround;
        [SerializeField] private List<SpriteRenderer> childList;

        private const float FadeInAnimationTime = 1f;
        private const Ease FadeInAnimationEase = Ease.InSine;

        private void Start()
        {
            foreach (var child in childList)
            {
                child.DOFade(1f, FadeInAnimationTime).SetEase(FadeInAnimationEase);
            }
            player.DOFade(1f, FadeInAnimationTime).SetEase(FadeInAnimationEase);
            backGround.DOFade(1f, FadeInAnimationTime).SetEase(FadeInAnimationEase);
        }
    }
}