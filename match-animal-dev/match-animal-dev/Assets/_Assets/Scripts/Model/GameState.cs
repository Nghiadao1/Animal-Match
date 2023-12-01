using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : PermanentMonoBehaviourSingleton<GameState>
{
    [SerializeField] private GameModel gameModel;
    public GameManager GameManager => GameManager.Instance;
    void Start()
    {

    }
    public void LoadLevel(int level)
    {
        // GameManager.LoadLevel(gameModels[level]);
    }
}
