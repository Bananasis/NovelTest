using Naninovel;

[CommandAlias("memoryGame")]
public class StartMemoryGame : Command
{
    /// <summary>
    /// Duration (in seconds) of the show animation. 
    /// When not specified, will use UI-specific duration.
    /// </summary>
    [ParameterAlias("time")] public DecimalParameter Duration;

    public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var memoryGameService = Engine.GetService<MemoryGameService>();
        await memoryGameService.miniGameUi.ChangeVisibilityAsync(true, Assigned(Duration) ? Duration : null);
        await UniTask.Run(async () =>
        {
            await UniTask.SwitchToMainThread();
            memoryGameService.miniGameController.StartGame();
        });
        // await UniTask.Run(memoryGameService.miniGameController.StartGame,false);
        await UniTask.WaitUntil(() => memoryGameService.miniGameController.isFinished);
        await memoryGameService.miniGameUi.ChangeVisibilityAsync(false, Assigned(Duration) ? Duration : null);
    }
}