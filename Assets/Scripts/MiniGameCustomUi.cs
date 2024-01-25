using System.Collections;
using System.Collections.Generic;
using DTT.MinigameMemory;
using DTT.MinigameMemory.Demo;
using Naninovel.UI;
using UnityEngine;

public class MiniGameCustomUi : CustomUI,IMiniGameCustomUI
{
    [SerializeField] private GameStarter _gameStarter;
    [SerializeField] private MemoryGameManager _memoryGameManager;
    public void StartGame()=> _gameStarter.StartGame();
    public bool isFinished => !_memoryGameManager.IsGameActive;
}
