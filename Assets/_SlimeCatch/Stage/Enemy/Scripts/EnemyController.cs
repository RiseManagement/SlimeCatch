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

	private GameObject wavecontrollerObject;

	private void Awake()
    {
        _transform = GetComponent<Transform>();
        _weaponDecision = GetComponent<WeaponDecision>();

		//ヒエラルキー上のWaveControllerObjectを取得
		wavecontrollerObject = GameObject.Find("WaveController");
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
            var weaponObject = Instantiate(weaponInfo.WeaponGameObject, transform);

			weaponObject.GetComponent<IWeaponMove>().WeaponMove(ChildSlimeAimTargetPosition(), weaponInfo.WeaponOrbit);

			await UniTask.Delay(TimeSpan.FromSeconds(2f));
            AttackFinish = true;
            Destroy(weaponObject);
        }
    }

	/// <summary>
	/// 子供スライムに攻撃するターゲット
	/// </summary>
	/// <returns></returns>
	Vector3 ChildSlimeAimTargetPosition()
	{
		_SlimeCatch.Wave.WaveController wavecontroller = wavecontrollerObject.GetComponent<_SlimeCatch.Wave.WaveController>();	//wavecontrollerスクリプト取得
		GameObject childsslimesObject = wavecontroller.ChildsSlimesObject;	//子供スライムObject取得
		int childcount = childsslimesObject.transform.childCount;	//生存している子供スライムの数を数える
		var r = UnityEngine.Random.Range(0, childcount);    //子供スライム選び中
		var childslime = childsslimesObject.transform.GetChild(r);	//ターゲット確定

		return childslime.position;  //狙う子供スライムの座標を返す
	}
}
