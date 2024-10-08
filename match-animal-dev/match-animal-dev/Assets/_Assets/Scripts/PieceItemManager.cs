using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PieceItemManager : TemporaryMonoBehaviourSingleton<PieceItemManager>
{
    [SerializeField] private List<PieceItemHandler> pieceItemHandlers;
    public List<PieceItemHandler> pieceWaits = new List<PieceItemHandler>();
    public bool IsWin => IsPieceItemNull();
    // private void Start()
    // {
    //     InitPieceBoard();
    // }

    //[SerializeField] private Transform pieceItemRoot;
    public List<Transform> pieceItemRoots;
    public List<LayerController> layerControllers = new List<LayerController>();
    public List<PieceItemHandler> PieceItemHandlers
    {
        get => pieceItemHandlers;
        private set => pieceItemHandlers = value;
    }

    public PieceItemHandler[,] PieceBoard { get; private set; }

    private GameModel GameModel => GameModel.Instance;
    WaitLine WaitLine => WaitLine.Instance;
    private int Row => GameModel.Row;
    private int Column => GameModel.Column;

    public PieceBoardModel BoardModel { get; private set; }
    public void InitPieceLayer()
    {
        pieceItemHandlers = new List<PieceItemHandler>();
        PieceBoard = new PieceItemHandler[Row, Column];
        for (int i = 0; i < pieceItemRoots.Count; i++)
        {
            var pieceBoardModel = GameModel.GetPieceBoardModel(i);
            InitPieceBoard(pieceBoardModel, i);
        }
    }
    public void InitPieceBoard(PieceBoardModel boardModel, int layer)
    {
        BoardModel = boardModel;
        Debug.Log("layer " + layer);
        for (var row = 0; row < Row; row++)
            for (var column = 0; column < Column; column++)
            {
                //var index = row * Column + column;
                var pieceModel = BoardModel[row, column];
                pieceModel.Position = new Position(row, column);
                var pieceItemHandler = GetPieceItemHandler(pieceModel.Type, pieceItemRoots[layer]);
                pieceItemHandler.layerPiece = layer + 1;
                pieceItemHandlers.Add(pieceItemHandler);
                PieceBoard[row, column] = pieceItemHandler;
                pieceItemHandler.SetData(pieceModel);
                pieceItemHandler.gameObject.name = row + " " + column;

            }
    }
    public void Isblocked(PieceItemHandler pieceItem)
    {
        var row = pieceItem.Position.Row;
        var column = pieceItem.Position.Column;
        var direction = pieceItem.direction;
        pieceItem._canPutOn = true;
        foreach (var dir in direction)
        {
            var newRow = row + dir.x;
            var newColumn = column + dir.y;
            var newLayer = pieceItem.layerPiece + 1;
            while (newLayer < pieceItemHandlers.Count)
            {
                foreach (var piece in PieceItemHandlers)
                {
                    if (piece != null && piece.Position.Row == newRow && piece.Position.Column == newColumn && piece.layerPiece == newLayer)
                    {
                        //Debug.Log("Piece: " + piece.Position.Row + " " + piece.Position.Column + " " + piece.layerPiece + " " + pieceItem.layerPiece + " " + pieceItem.Position.Row + " " + pieceItem.Position.Column);
                        pieceItem._canPutOn = false;
                        break;
                    }
                }
                newLayer++;
            }
        }
    }
    public bool IsPieceItemNull()
    {
        return PieceItemHandlers.Count == 0;
    }
    private PieceItemHandler GetPieceItemHandler(PieceType type, Transform root)
    {
        return GameModel.GetPieceItemInstance(type, root);
    }

    public bool IsLocatedOn(PieceItemHandler piece)
    {
        return PieceBoard[piece.Position.Row, piece.Position.Column] != null;
    }
    public void RemoveFromPieceBoard(PieceItemHandler pieceItem)
    {
        PieceBoard[pieceItem.Position.Row, pieceItem.Position.Column] = null;
        pieceItemHandlers.Remove(pieceItem);
    }
    public void Restart()
    {
        foreach (var itemRoot in pieceItemRoots)
        {
            //destroy all piece item in itemRoot
            foreach (Transform child in itemRoot)
            {
                PieceItemManager.Instance.RemoveFromPieceBoard(child.GetComponent<PieceItemHandler>());
                Destroy(child.gameObject, 0f);
            }
        }
    }
    public void RestartLayer()
    {
        foreach (var itemRoot in pieceItemRoots)
        {
            var girdLayoutGroup = itemRoot.gameObject.GetComponent<EnableGird>();
            girdLayoutGroup.Restart();
        }
    }
    public void AddToPieceBoard(PieceItemHandler pieceItem)
    {
        PieceBoard[pieceItem.Position.Row, pieceItem.Position.Column] = pieceItem;

    }
    private List<PieceItemHandler> pieceSameType = new List<PieceItemHandler>();
    public void FindPieceSameType()
    {
        PieceItemHandler pieceItem = FindFirstPieceHint();
        var type = pieceItem.Type;
        var count = 0;
        FintLastPieceHint(type, ref count);
        CheckCount(count);
    }

    private void CheckCount(int count)
    {
        if (count < 2)
        {
            Debug.Log("---------------done------------------");
            foreach (var pieceSame in pieceSameType)
            {
                WaitLine.AddPiece(pieceSame);
            }
            pieceSameType.Clear();
        }
    }

    private PieceItemHandler FindFirstPieceHint()
    {
        var pieceItem = PieceItemHandlers[0];
        if (pieceWaits.Count > 0) pieceItem = pieceWaits[Random.Range(0, pieceWaits.Count)];
        else
        {
            pieceItem = PieceItemHandlers[Random.Range(0, PieceItemHandlers.Count)];
            WaitLine.AddPiece(pieceItem);
        }

        return pieceItem;
    }

    private void FintLastPieceHint(PieceType type, ref int count)
    {
        foreach (var piece in PieceItemHandlers)
            if (piece != null && piece.Type == type)
            {
                pieceSameType.Add(piece);
                count++;
                Debug.Log("count " + pieceSameType);
                if (pieceSameType.Count == 2)
                {
                    foreach (var pieceSame in pieceSameType) WaitLine.AddPiece(pieceSame);
                    pieceSameType.Clear();
                    return;
                }
            }
    }
    public void ClearOldData()
    {
        foreach (var piece in PieceItemHandlers) Destroy(piece.gameObject);
        foreach (var layer in layerControllers) Destroy(layer.gameObject);
        PieceItemHandlers.Clear();
        layerControllers.Clear();
        pieceItemRoots.Clear();
    }
    public void CheckIsBlocked()
    {
        foreach (var piece in PieceItemHandlers)
        {
            if (piece != null)
            {
                Isblocked(piece);
                PieceItemHandler.UpdateColor(piece);
            }
        }
    }
}

