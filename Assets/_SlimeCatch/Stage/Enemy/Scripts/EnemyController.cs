using System;
using _SlimeCatch.Player;
using _SlimeCatch.Weapon;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _SlimeCatch.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private const float BackEndPosition = -10f;

        [SerializeField, Label("移動時間"), Range(1, 5)]
        private float moveTime;

        public bool AttackFinish { get; private set; }
        public bool MoveEnd { get; private set; }

        [SerializeField] private EnemyObject enemyObject;
        private Transform _transform;

        private WeaponDecision _weaponDecision;
        private const int EnemyThrowWeaponCount = 4;
        private ChildSlimeList _childSlimeList;
        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _weaponDecision = GetComponent<WeaponDecision>();
            _childSlimeList = FindObjectOfType<ChildSlimeList>();
        }

        // Start is called before the first frame update
        private async void Start()
        {
            var randomMoveXDistance = Random.Range(-7.6f, -2f);
            await Walk(randomMoveXDistance, moveTime);
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            AttackFinish = true;
            await ThrowWeapon();
            _transform.Rotate(new Vector3(0f, 180f, 0f));
            await Walk(BackEndPosition, moveTime);
            MoveEnd = true;
            Destroy(gameObject);
        }

        private async UniTask Walk(float distance, float time)
        {
            await transform.DOMoveX(distance, time).ToAwaiter();
        }

        private async UniTask ThrowWeapon()
        {
            var high = 0f;
            switch (enemyObject.EnemySize)
            {
                case 2:
                    high = -0.5f;
                    break;
                case 3:
                    high = 1.5f;

                    break;
                case 4:
                    high = 2.5f;

                    break;
                case 6:
                    high = 3.5f;

                    break;
            }

            for (var throwIndex = 0; throwIndex < EnemyThrowWeaponCount; throwIndex++)
            {
                WeaponObject weaponInfo;
                if (enemyObject.SpecialWeapon != WeaponEnum.None && throwIndex % 2 == 0)
                {
                    weaponInfo = _weaponDecision.WeaponOrbitSearch(enemyObject.SpecialWeapon);
                }
                else
                {
                    weaponInfo = _weaponDecision.WeaponOrbitSearch(enemyObject.BaseWeapon);
                }

                var weaponObject = Instantiate(weaponInfo.WeaponGameObject, new Vector3(-5.2f, high, 0), Quaternion.Euler(0, 180, 40), transform);
                weaponObject.GetComponent<IWeaponMove>().WeaponMove(_childSlimeList.GetAliveSlimePosition(), weaponInfo.WeaponOrbit);
                await UniTask.Delay(TimeSpan.FromSeconds(2f));
                Destroy(weaponObject);
            }
        }
    }
}