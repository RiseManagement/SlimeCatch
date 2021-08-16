using System;
using _SlimeCatch.Stage.Gimmick;
using UniRx;
using UnityEngine;

public class GimmickAreaCollider : MonoBehaviour
{
    private readonly Subject<int> _isDamageForGimmickSubject = new Subject<int>();

    [SerializeField,Min(0)] private int gimmickDeathSlimeCount;
    [SerializeField] private GimmickEnum gimmickEnum;
    public IObservable<int> IsDamageForGimmickObservable() => _isDamageForGimmickSubject;

    private void Start()
    {
        IsDamageForGimmickObservable().Skip(1).Subscribe(value =>
        {
            Debug.Log($"ギミックに当たって死ぬ子スライムの数:{gimmickDeathSlimeCount}");
        }).AddTo(this);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag($"Gimmick/{gimmickEnum}") && !other.gameObject.CompareTag("Player"))
        {
            _isDamageForGimmickSubject.OnNext(gimmickDeathSlimeCount);
        }
    }
}
