using System;
using System.Runtime.CompilerServices;
using System.Threading;
using DG.Tweening;

public struct TweenAwaiter : ICriticalNotifyCompletion
{
    private readonly Tween _tween;
    private CancellationToken _cancellationToken;

    public TweenAwaiter(Tween tween, CancellationToken cancellationToken)
    {
        this._tween = tween;
        this._cancellationToken = cancellationToken;
    }

    public bool IsCompleted => !_tween.IsPlaying();

    public void GetResult() => _cancellationToken.ThrowIfCancellationRequested();

    public void OnCompleted(Action continuation) => UnsafeOnCompleted(continuation);

    public void UnsafeOnCompleted(Action continuation)
    {
        CancellationTokenRegistration regist = new CancellationTokenRegistration();
        var tween = this._tween;

        // Tweenが死んだら続きを実行
        tween.OnKill(() =>
        {
            regist.Dispose(); // CancellationTokenRegistrationを破棄する
            continuation(); // 続きを実行
        });

        // tokenが発火したらTweenをKillする
        regist = _cancellationToken.Register(()=>{
            tween.Kill(true);
        });
    }

    public TweenAwaiter GetAwaiter() => this;
}

public static class TweenAwaiterEx
{
    // TweenにToAwaiter拡張メソッドを追加
    public static TweenAwaiter ToAwaiter(this Tween self, CancellationToken cancellationToken = default)
    {
        return new TweenAwaiter(self, cancellationToken);
    }
}