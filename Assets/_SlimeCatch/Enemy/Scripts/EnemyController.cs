using System;
using System.Collections.Generic;
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
        await weaponList.ToUniTaskAsyncEnumerable().ForEachAwaitAsync(async x =>
        {
            var weaponObject = Instantiate(x, transform);
            weaponObject.GetComponent<IWeaponMove>().WeaponMove(new Vector3(5,0,0),WeaponOrbitEnum.Curve);
            await UniTask.Delay(TimeSpan.FromSeconds(2f));
            Destroy(weaponObject);
        });
    }
}
