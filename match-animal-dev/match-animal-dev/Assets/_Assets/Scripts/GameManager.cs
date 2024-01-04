using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : TemporaryMonoBehaviourSingleton<GameManager>
{

    public int Level;
    [SerializeField] private UnityEvent onPieceMatches;
    [SerializeField] private Transform pieceItemPick;
    private WaitLine WaitLine => WaitLine.Instance;
    public GameModel GameModel => GameModel.Instance;
    private PieceItemManager PieceItemManager => PieceItemManager.Instance;
    private PanelManager PanelManager => PanelManager.Instance;
    public UnityEvent OnPieceMatches
    {
        get => onPieceMatches;
        set => onPieceMatches = value;
    }
    private void Start()
    {
        Init();
    }
    void Update()
    {
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.Level, Level);
    }
    private void Init()
    {
        Level = DatabaseManager.LoadData<int>(DatabaseManager.DatabaseKey.Level, "1");
        LoadData();
        OnPieceMatches.AddListener(() => { Debug.LogError(" OnPieceMatches!"); });
    }

    private void LoadData()
    {
        GameState.Instance.LoadData();
        PieceItemManager.InitPieceLayer();
    }

    public void Pick(PieceItemHandler pieceItem)
    {
        if (WaitLine.CanPutOn && pieceItem._canPutOn)
        {
            ItemManager.Instance.AddInfoPiece(pieceItem);
            WaitLine.AddPiece(pieceItem);
            Debug.Log("Can put on");
        }
        else if (!WaitLine.CanPutOn) LoseGame();
        else Debug.Log("Can't put on");
    }
    public void WinGame()
    {
        if (PieceItemManager.IsWin) PanelManager.ShowPanelWin();
    }
    private void LoseGame()
    {
        PanelManager.ShowPanelLose();
    }
    public void Restart()
    {
        PieceItemManager.Restart();
        WaitLine.Restart();
    }
    public void Reverse()
    {
        // WaitLine.Reverse();
    }
    private void ClearOldData()
    {
        PieceItemManager.ClearOldData();
        WaitLine.Restart();
    }
    public void NextLevel()
    {
        Level++;
        ClearOldData();
        GameState.Instance.Restart();
        LoadData();
        PieceItemManager.RestartLayer();
    }

}
