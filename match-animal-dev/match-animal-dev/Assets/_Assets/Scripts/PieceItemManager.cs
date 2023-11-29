using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceItemManager : TemporaryMonoBehaviourSingleton<PieceItemManager>
{
    [SerializeField] private List<PieceItemHandler> pieceItemHandlers;

    // private void Start()
    // {
    //     InitPieceBoard();
    // }

    //[SerializeField] private Transform pieceItemRoot;
    [SerializeField] private List<Transform> pieceItemRoots;
    public List<PieceItemHandler> PieceItemHandlers
    {
        get => pieceItemHandlers;
        private set => pieceItemHandlers = value;
    }

    public PieceItemHandler[,] PieceBoard { get; private set; }

    private GameModel GameModel => GameModel.Instance;

    private int Row => GameModel.Row;
    private int Column => GameModel.Column;

    public PieceBoardModel BoardModel { get; private set; }




    public void InitPieceBoard(PieceBoardModel boardModel)
    {
        BoardModel = boardModel;
        pieceItemHandlers = new List<PieceItemHandler>();
        PieceBoard = new PieceItemHandler[Row, Column];
        for (var row = 0; row < Row; row++)
            for (var column = 0; column < Column; column++)
            {
                var index = row * Column + column;
                var pieceModel = BoardModel[row, column];
                pieceModel.Position = new Position(row, column);
                for (var i = 0; i < pieceItemRoots.Count; i++)
                {
                    var pieceItemHandler = GetPieceItemHandler(pieceModel.Type, pieceItemRoots[i]);
                    pieceItemHandler.gameObject.tag = "Piece" + (i + 1).ToString();
                    pieceItemHandler.layerPiece = i + 1;
                    pieceItemHandlers.Add(pieceItemHandler);
                    PieceBoard[row, column] = pieceItemHandler;
                    Debug.Log(pieceItemHandler.Position.Row + " " + pieceItemHandler.Position.Column);
                    pieceItemHandler.SetData(pieceModel);
                    pieceItemHandler.gameObject.name = row + " " + column;
                }
            }
    }

    private PieceItemHandler GetPieceItemHandler(PieceType type, Transform root)
    {
        return GameModel.GetPieceItemInstance(type, root);
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

            if (newRow >= 0 && newRow < Row && newColumn >= 0 && newColumn < Column)
            {
                var piece = PieceBoard[newRow, newColumn];
                if (piece != null && piece.layerPiece > pieceItem.layerPiece)
                {
                    pieceItem._canPutOn = false;
                    break;
                }
            }
        }
    }
    public bool IsLocatedOn(PieceItemHandler piece)
    {
        return PieceBoard[piece.Position.Row, piece.Position.Column] != null;
    }
    public void RemoveFromPieceBoard(PieceItemHandler pieceItem)
    {
        // PieceBoard[pieceItem.Position.Row, pieceItem.Position.Column] = null;
        //disable pieceItem and remove from PieceBoard
        //pieceItem.gameObject.SetActive(false);
        PieceBoard[pieceItem.Position.Row, pieceItem.Position.Column] = null;
    }
}

