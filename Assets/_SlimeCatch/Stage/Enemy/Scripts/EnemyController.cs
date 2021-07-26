using System;
using System.Collections.Generic;
using _SlimeCatch.Weapon;
using _SlimeCatch.Enemy;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField,Label("移動距離(ベクトル)"),Range(1,5)] private float moveDistance;

    [SerializeField,Label("移動時間"),Range(1,5)] private float moveTime;

    [SerializeField] private List<GameObject> weaponList;

    public bool AttackFinish { get; private set; }
    public bool MoveEnd { get; private set; }

    [SerializeField] private EnemyObject enemyObject;

    private WeaponNameDecision _weaponNameDecision;

    private void Awake()
    {
        _weaponNameDecision = GetComponent<WeaponNameDecision>();
    }

    // Start is called before the first frame update
    private async void Start()
    {
        await Walk(moveDistance,moveTime);
        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        await ThrowWeapon();
        await Walk(-moveDistance, moveTime);
        MoveEnd = true;
        Destroy(gameObject);
    }

    private async UniTask Walk(float distance,float time)
    {
        await transform.DOMoveX(distance, time).SetRelative(true).ToAwaiter();
    }

    private async UniTask ThrowWeapon()
    {
        var isBaseWeapon = false;
        var weaponOrbit = WeaponOrbitEnum.Line;
        await weaponList.ToUniTaskAsyncEnumerable().ForEachAwaitAsync(async x =>
        {
            // todo この分岐をEnemyObjectの武器を参照する
            var weaponObject = Instantiate(x, transform);
            // if (isBaseWeapon)
            // {
            //     weaponOrbit = _weaponNameDecision.WeaponOrbitSearch(enemyObject.BaseWeapon);
            //     Debug.Log($"orbit:{weaponOrbit}");
            //     isBaseWeapon = false;
            // }
            // else
            // {
            //     weaponOrbit = _weaponNameDecision.WeaponOrbitSearch(enemyObject.SpecialWeapon);
            //     Debug.Log($"orbit:{weaponOrbit}");
            //     isBaseWeapon = true;
            // }
            weaponObject.GetComponent<IWeaponMove>().WeaponMove(new Vector3(5,0,0),weaponOrbit);
            await UniTask.Delay(TimeSpan.FromSeconds(2f));
            AttackFinish = true;
            Destroy(weaponObject);
        });
    }
}
