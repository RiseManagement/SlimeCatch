using System;
using System.Threading;
using System.Threading.Tasks;
using _SlimeCatch.Stage.Gimmick.Wetland.Scripts;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ChildSinkDeath : MonoBehaviour
{
    private CancellationTokenSource hoge = null;


    public async Task CancelToken()
    {
        hoge.Cancel();
        GetComponent<ChildAnimationHandler>().ChildFloat();
    }

    public async UniTask SinkDeath()
    {
        hoge = new CancellationTokenSource();

        await UniTask.Delay(TimeSpan.FromSeconds(15f), cancellationToken: hoge.Token);

        this.gameObject.SetActive(false);
    }
}