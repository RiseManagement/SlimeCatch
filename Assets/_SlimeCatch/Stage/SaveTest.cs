using System;
using _SlimeCatch.Save;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace _SlimeCatch.Stage
{
    public class SaveTest : MonoBehaviour
    {
        private ISaveController _saveController;

        private void Awake()
        {
            _saveController = new SaveLoadController();
        }

        private void Start()
        {
            this.UpdateAsObservable()
                .Subscribe(_ =>
                {
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        _saveController.Save(5,true);
                    }else if (Input.GetKeyDown(KeyCode.R))
                    {
                        _saveController.Save(5,false);
                    }
                }).AddTo(this);
        }
    }
}