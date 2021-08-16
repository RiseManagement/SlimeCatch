using System;
using _SlimeCatch.Player;
using _SlimeCatch.Stage.Gimmick;
using UniRx;
using UnityEngine;

public class GimmickAreaCollider : MonoBehaviour
{
    private readonly Subject<int> _isDamageForGimmickSubject = new Subject<int>();

    [SerializeField,Min(0)] private int gimmickDeathSlimeCount;
    private IObservable<int> IsDamageForGimmickObservable() => _isDamageForGimmickSubject;
    [SerializeField] private ChildSlimeList childSlimeList;

    private void Start()
    {
        IsDamageForGimmickObservable().Subscribe(value =>
        {
            Debug.Log($"ギミックに当たって死ぬ子スライムの数:{gimmickDeathSlimeCount}");
            childSlimeList.DamageGimmick(value);
        }).AddTo(this);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag($"Gimmick") && !other.gameObject.CompareTag("Player"))
        {
            _isDamageForGimmickSubject.OnNext(gimmickDeathSlimeCount);
        }
    }
}
