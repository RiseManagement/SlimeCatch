using System.Collections.Generic;
using System.Linq;
using _SlimeCatch.Save;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _SlimeCatch.Stage
{
    public class SaveTest : MonoBehaviour
    {
        private SaveLoadController _saveController;
        [SerializeField] private List<GameObject> switchButtonList;
        private readonly Subject<int> _onClickButtonSubject = new Subject<int>();

        private void Awake()
        {
            _saveController = new SaveLoadController();
            foreach (var (button,index) in switchButtonList.Select((button,index) => (button,index)))
            {
                button.GetComponent<Button>().OnClickAsObservable().Subscribe(_ =>
                {
                    _onClickButtonSubject.OnNext(index);
                }).AddTo(this);
            }

            foreach (var (data,index) in _saveController.GetStageClearList().Select((data,index) => (data,index)))
            {

                switchButtonList[index].GetComponent<Image>().color = ChangeButtonColor(data);
            }
        }

        private void Start()
        {
            _onClickButtonSubject.Subscribe(value =>
            {
                Debug.Log($"押されたボタン:{value}");
                var clearData = _saveController.GetStageClearList()[value];
                _saveController.Save(value,!clearData);
                switchButtonList[value].GetComponent<Image>().color = ChangeButtonColor(!clearData);
            }).AddTo(this);
        }

        private Color ChangeButtonColor(bool isClear)
        {
            return isClear ? Color.red : Color.blue;
        }
    }
}