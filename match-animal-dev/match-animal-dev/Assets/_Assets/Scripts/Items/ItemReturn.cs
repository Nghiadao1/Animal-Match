using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks.Sources;
using System.Linq;

public class ItemReturn : TemporaryMonoBehaviourSingleton<ItemReturn>
{
    private PieceItemManager pieceItemManager => PieceItemManager.Instance;
    private WaitLine waitline => WaitLine.Instance;
    private List<Vector3> piecePositions = new List<Vector3>();
    private List<Position> piecePositionsDashboard = new List<Position>();
    private Stack<Action> pieceMovementHistory = new Stack<Action>();
    private Dictionary<PieceItemHandler, int> originalLayerPieces = new Dictionary<PieceItemHandler, int>();
    private Dictionary<PieceItemHandler, int> pieceIndices = new Dictionary<PieceItemHandler, int>();
    public void AddInfoPiece(PieceItemHandler piece)
    {
        piecePositions.Add(piece.transform.position);
        piecePositionsDashboard.Add(piece.Model.Position);
        pieceIndices[piece] = piecePositions.Count - 1;
        originalLayerPieces[piece] = piece.layerPiece;
        pieceMovementHistory.Push(() => AddInfoPiece(piece));
    }

    public void Clear(PieceItemHandler piece)
    {
        piecePositions.Remove(piece.transform.position);
        piecePositionsDashboard.Remove(piece.Model.Position);
        pieceMovementHistory.Push(() => Clear(piece));
    }

    public void UndoPiece()
    {
        while (pieceItemManager.pieceWaits.Count > 0)
        {
            Undo();
        }
        waitline.Reverse();
        pieceMovementHistory.Push(UndoPiece);
    }

    private void Undo()
    {
        var piece = pieceItemManager.pieceWaits.Last();
        int index = pieceIndices[piece];
        UndoData(piece, index);
        RemovePieceDataInList(piece, index);
    }

    private void RemovePieceDataInList(PieceItemHandler piece, int index)
    {
        pieceItemManager.pieceWaits.Remove(piece);
        piecePositions.RemoveAt(index);
        piecePositionsDashboard.RemoveAt(index);
    }

    private void UndoData(PieceItemHandler piece, int index)
    {
        piece.transform.DOMove(piecePositions[index], 0.5f);
        piece.Model.Position = piecePositionsDashboard[index];
        piece.transform.SetParent(pieceItemManager.pieceItemRoots[piece.layerPiece - 1].transform);
        pieceItemManager.PieceBoard[piece.Model.Position.Row, piece.Model.Position.Column] = piece;
        pieceItemManager.PieceItemHandlers.Add(piece);
        piece.isInWaitLine = false;
        if (originalLayerPieces.ContainsKey(piece)) piece.layerPiece = originalLayerPieces[piece];
    }

    public void RedoPiece()
    {
        if (pieceMovementHistory.Count > 0)
        {
            Action lastAction = pieceMovementHistory.Pop();
            lastAction();
        }
    }
}