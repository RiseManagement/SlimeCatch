using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class ChildSlimeList : MonoBehaviour
{
    private readonly List<GameObject> _slimeChild = new List<GameObject>();
    [SerializeField] private GameObject chileSlimes;
    private readonly Subject<int> _damageSlimeChild = new Subject<int>();
    private const int MAXOffActiveCount = 2;
    private readonly List<GameObject> _aliveChildSlimeList = new List<GameObject>();

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
            SlimeNoActive();
            SetAliveSlime();
        }).AddTo(this);
    }

    private void SlimeNoActive()
    {
        var count = 0;
        foreach (var child in _slimeChild.Where(child => child.activeSelf && count < MAXOffActiveCount))
        {
            child.SetActive(false);
            count++;
        }
    }

    private void SetAliveSlime()
    {
        foreach (var child in _slimeChild.Where(child => child.activeSelf))
        {
            _aliveChildSlimeList.Add(child);
        }
    }

    public Vector3 GetAliveSlime()
    {
        var r = Random.Range(0, _aliveChildSlimeList.Count-1);
        return _aliveChildSlimeList[r].transform.position;
    }
}