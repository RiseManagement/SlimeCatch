using System.Threading;
using System.Threading.Tasks;
using _SlimeCatch.Stage.Gimmick.Wetland.Scripts;
using Cysharp.Threading.Tasks;
using UnityEngine;
using static System.TimeSpan;


public class ChildSinkDeath : MonoBehaviour
{
    private CancellationTokenSource hoge = null;


    public async Task CancelToken()
    {
        Debug.Log("キャンセル");
        hoge.Cancel();
        GetComponent<ChildAnimationHandler>().ChildFloat();
    }

    public async UniTask SinkDeath()
    {
        hoge = new CancellationTokenSource();

        await UniTask.Delay(FromSeconds(15f), cancellationToken: hoge.Token);

        this.gameObject.SetActive(false);
    }
}