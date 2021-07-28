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

    public bool AttackFinish { get; private set; }
    public bool MoveEnd { get; private set; }

    [SerializeField] private EnemyObject enemyObject;
    private Transform _transform;

    private WeaponDecision _weaponDecision;
    private const int EnemyThrowWeaponCount = 4;
    
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _weaponDecision = GetComponent<WeaponDecision>();
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
        if (distance < 0)
        {
            _transform.Rotate(new Vector3(0f,180f,0f));
        }
        await transform.DOMoveX(distance, time).SetRelative(true).ToAwaiter();
    }

    private async UniTask ThrowWeapon()
    {
        
        if (enemyObject.EnemySize == 2)
        {
            
            for (var throwIndex = 0; throwIndex < EnemyThrowWeaponCount; throwIndex++)
            {
                WeaponObject weaponInfo = null;
                if (enemyObject.SpecialWeapon != WeaponEnum.None && throwIndex % 2 == 0)
                {
                    weaponInfo = _weaponDecision.WeaponOrbitSearch(enemyObject.SpecialWeapon);
                }
                else
                {
                    weaponInfo = _weaponDecision.WeaponOrbitSearch(enemyObject.BaseWeapon);
                }

                var weaponObject = Instantiate(weaponInfo.WeaponGameObject, new Vector3(-5.2f, -0.5f, 0), Quaternion.Euler(0, 180, 40), transform);
                weaponObject.GetComponent<IWeaponMove>().WeaponMove(new Vector3(5, 0, 0), weaponInfo.WeaponOrbit);
                await UniTask.Delay(TimeSpan.FromSeconds(2f));
                AttackFinish = true;
                Destroy(weaponObject);
            }
        }
        if (enemyObject.EnemySize == 3)
        {
            
            for (var throwIndex = 0; throwIndex < EnemyThrowWeaponCount; throwIndex++)
            {
                WeaponObject weaponInfo = null;
                if (enemyObject.SpecialWeapon != WeaponEnum.None && throwIndex % 2 == 0)
                {
                    weaponInfo = _weaponDecision.WeaponOrbitSearch(enemyObject.SpecialWeapon);
                }
                else
                {
                    weaponInfo = _weaponDecision.WeaponOrbitSearch(enemyObject.BaseWeapon);
                }

                var weaponObject = Instantiate(weaponInfo.WeaponGameObject, new Vector3(-5.2f, -0.125f, 0), Quaternion.Euler(0, 180, 40), transform);
                weaponObject.GetComponent<IWeaponMove>().WeaponMove(new Vector3(5, 0, 0), weaponInfo.WeaponOrbit);
                await UniTask.Delay(TimeSpan.FromSeconds(2f));
                AttackFinish = true;
                Destroy(weaponObject);
            }
        }
        if (enemyObject.EnemySize == 4)
        {
            
            for (var throwIndex = 0; throwIndex < EnemyThrowWeaponCount; throwIndex++)
            {
                WeaponObject weaponInfo = null;
                if (enemyObject.SpecialWeapon != WeaponEnum.None && throwIndex % 2 == 0)
                {
                    weaponInfo = _weaponDecision.WeaponOrbitSearch(enemyObject.SpecialWeapon);
                }
                else
                {
                    weaponInfo = _weaponDecision.WeaponOrbitSearch(enemyObject.BaseWeapon);
                }

                var weaponObject = Instantiate(weaponInfo.WeaponGameObject, new Vector3(-5.2f, 0.2f, 0), Quaternion.Euler(0, 180, 40), transform);
                weaponObject.GetComponent<IWeaponMove>().WeaponMove(new Vector3(5, 0, 0), weaponInfo.WeaponOrbit);
                await UniTask.Delay(TimeSpan.FromSeconds(2f));
                AttackFinish = true;
                Destroy(weaponObject);
            }
        }
        if (enemyObject.EnemySize == 6)
        {
            
            for (var throwIndex = 0; throwIndex < EnemyThrowWeaponCount; throwIndex++)
            {
                WeaponObject weaponInfo = null;
                if (enemyObject.SpecialWeapon != WeaponEnum.None && throwIndex % 2 == 0)
                {
                    weaponInfo = _weaponDecision.WeaponOrbitSearch(enemyObject.SpecialWeapon);
                }
                else
                {
                    weaponInfo = _weaponDecision.WeaponOrbitSearch(enemyObject.BaseWeapon);
                }

                var weaponObject = Instantiate(weaponInfo.WeaponGameObject, new Vector3(-5.2f, 0.625f, 0), Quaternion.Euler(0, 180, 40), transform);
                weaponObject.GetComponent<IWeaponMove>().WeaponMove(new Vector3(5, 0, 0), weaponInfo.WeaponOrbit);
                await UniTask.Delay(TimeSpan.FromSeconds(2f));
                AttackFinish = true;
                Destroy(weaponObject);
            }
        }
    }
}
