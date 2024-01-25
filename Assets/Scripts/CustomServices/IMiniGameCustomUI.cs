using Naninovel.UI;


public interface IMiniGameController
{
    public void StartGame();
    public bool isFinished { get; }
}

public interface IMiniGameCustomUI:IManagedUI,IMiniGameController
{
   
}