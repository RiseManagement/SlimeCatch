using System.Collections.Generic;
using System.Linq;
using _SlimeCatch.Stage.Gimmick.Wetland.Scripts;
using NaughtyAttributes;
using UniRx;
using UnityEngine;

namespace _SlimeCatch.Player
{
    public class ChildSlimeList : MonoBehaviour
    {
        private readonly List<GameObject> _slimeChild = new List<GameObject>();
        [SerializeField] private GameObject chileSlimes;
        private readonly Subject<int> _damageSlimeChild = new Subject<int>();
        private const int MAXOffActiveCount = 2;
        private readonly List<GameObject> _aliveChildSlimeList = new List<GameObject>();
        public int GetAliveSlimeChildCount => _aliveChildSlimeList.Count;

        [Button("ChildrenFloat")]
        private void ChildrenFloatTest()
        {
            ChildrenFloat();
        }

        private void Awake()
        {
            foreach (Transform child in chileSlimes.transform)
            {
                _slimeChild.Add(child.gameObject);
            }

            SetAliveSlime();
        }

        private void Start()
        {
            foreach (var (child, index) in _slimeChild.Select((item, index) => (item, index)))
            {
                child.GetComponent<ChildrenSlimeWeaponCollider>().IsAttack.Subscribe(_ => _damageSlimeChild.OnNext(index));
            }

            _damageSlimeChild.Subscribe(value =>
            {

                _slimeChild[value].SetActive(false);
                SlimeNoActive(MAXOffActiveCount);
                SetAliveSlime();
            }).AddTo(this);
        }

        private void SlimeNoActive(int noActiveSlimeCount)
        {
            var count = 0;
            foreach (var child in _slimeChild.Where(child => child.activeSelf && count < noActiveSlimeCount))
            {
                child.SetActive(false);
                count++;
            }
        }

        private void SetAliveSlime()
        {
            _aliveChildSlimeList.Clear();
            foreach (var child in _slimeChild.Where(child => child.activeSelf))
            {
                _aliveChildSlimeList.Add(child);
            }
        }

        public Vector3 GetAliveSlimePosition()
        {
            var r = Random.Range(0, _aliveChildSlimeList.Count - 1);
            return 0 < GetAliveSlimeChildCount ? _aliveChildSlimeList[r].transform.position : Vector3.zero;
        }

        public void ChildrenFloat()
        {
            foreach (var child in _slimeChild)
            {
                child.GetComponent<ChildAnimationHandler>()?.ChildFloat();
            }
        }
    }
}
