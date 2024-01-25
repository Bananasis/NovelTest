using UnityEngine;
using Naninovel;
using Naninovel.Commands;
using Naninovel.UI;


[InitializeAtRuntime]
public class MemoryGameService : IEngineService
{
    private readonly IUIManager uiManager;
    private IMiniGameCustomUI _miniGameController;
    public IMiniGameController miniGameController => _miniGameController ??= uiManager.GetUI<IMiniGameCustomUI>();
    public IManagedUI miniGameUi => _miniGameController ??= uiManager.GetUI<IMiniGameCustomUI>();

    public MemoryGameService(IUIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    public UniTask InitializeServiceAsync()
    { 
        
        return UniTask.CompletedTask;
    }
    
    

    public void ResetService()
    {
        // Reset service state here.
    }

    public void DestroyService()
    {
        // Stop the service and release any used resources here.
    }
}