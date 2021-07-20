using System;
using System.Collections.Generic;
using _SlimeCatch.Enemy;
using _SlimeCatch.Weapon;
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

    [SerializeField] private EnemyObject enemyObject;

    [SerializeField] private WeaponNameDecision _weaponNameDecision;
    
    // Start is called before the first frame update
    private async void Start()
    {
        await Walk(moveDistance,moveTime);
        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        await ThrowWeapon();
        await Walk(-moveDistance, moveTime);
    }

    private async UniTask Walk(float distance,float time)
    {
        await transform.DOMoveX(distance, time).SetRelative(true).ToAwaiter();
    }

    private async UniTask ThrowWeapon()
    {
        var isBaseWeapon = false;
        var weaponOrbit=WeaponOrbitEnum.None;
        await weaponList.ToUniTaskAsyncEnumerable().ForEachAwaitAsync(async x  =>
        {
            var weaponObject = Instantiate(x, transform);
            if (isBaseWeapon)
            {
                weaponOrbit = _weaponNameDecision.WeaponOrbitSearch(enemyObject.BaseWeapon);
                isBaseWeapon = false;
            }
            else
            {
                weaponOrbit = _weaponNameDecision.WeaponOrbitSearch(enemyObject.SpecialWeapon);
                isBaseWeapon = true;
            }
            weaponObject.GetComponent<IWeaponMove>().WeaponMove(new Vector3(5,0,0),weaponOrbit);
            await UniTask.Delay(TimeSpan.FromSeconds(2f));
            Destroy(weaponObject);
        });
    }
}
