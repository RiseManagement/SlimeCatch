using System;
using System.Threading;
using System.Threading.Tasks;
using _SlimeCatch.Stage.Gimmick.Wetland.Scripts;
using Cysharp.Threading.Tasks;
using UnityEngine;
using static Cysharp.Threading.Tasks.UniTask;

public class ChildSinkDeath : MonoBehaviour
{
    private CancellationTokenSource _hoge = null;


    public async Task CancelToken()
    {
        _hoge.Cancel();
        GetComponent<ChildAnimationHandler>().ChildFloat();
    }

    public async UniTask SinkDeath()
    {
        _hoge = new CancellationTokenSource();

        await Delay(TimeSpan.FromSeconds(15f), cancellationToken: _hoge.Token);
        this.gameObject.SetActive(false);
    }
}