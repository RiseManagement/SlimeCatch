using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ThunderColliderManager : MonoBehaviour
{
    private BoxCollider2D _collider2D;
    float Colliderheight = 0.0f;

    private void Start()
    {
        _collider2D = GetComponent<BoxCollider2D>();
        HeightValueGet();
    }

    private void HeightValueGet()
    {
        DOTween.To(() => Colliderheight,
                (x) => Colliderheight = x,
                6.0f,
                2.8f).SetLoops(2, LoopType.Yoyo)
            .OnUpdate(ExtendCollider2D);
    }

    private void ExtendCollider2D()
    {
        _collider2D.size = new Vector3(6.299981f, Colliderheight);
        OnDestroy();
    }

    private void OnDestroy()
    {
        Destroy(this.gameObject, 6.1f);
    }
}