using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ChildSinkDeath : MonoBehaviour
{
    public async void SinkDeath()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(15f));
        this.gameObject.SetActive(false);
    }
}