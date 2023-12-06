using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : TemporaryMonoBehaviourSingleton<GameManager>
{

    public int level;
    // level nhận database từ index của boardPiece tương ứng
    public int Level
    {
        get => level;
        set => level = value;
    }
    [SerializeField] private UnityEvent onPieceMatches;
    [SerializeField] private Transform pieceItemPick;
    private WaitLine WaitLine => WaitLine.Instance;
    public GameModel GameModel => GameModel.Instance;
    private PieceItemManager PieceItemManager => PieceItemManager.Instance;
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
    }
    private void Init()
    {
        PieceItemManager.InitPieceLayer();
        OnPieceMatches.AddListener(() => { Debug.LogError(" OnPieceMatches!"); });
    }

    public void Pick(PieceItemHandler pieceItem)
    {
        if (WaitLine.CanPutOn && pieceItem._canPutOn)
        {
            WaitLine.AddPiece(pieceItem);
            Debug.Log("Can put on");
        }
        else if (!WaitLine.CanPutOn) LoseGame();
        else Debug.Log("Can't put on");
    }
    public void WinGame()
    {
        if (PieceItemManager.IsWin) Debug.Log("Win Game");
    }
    private void LoseGame()
    {
        Debug.Log("Lose Game");
    }

}
