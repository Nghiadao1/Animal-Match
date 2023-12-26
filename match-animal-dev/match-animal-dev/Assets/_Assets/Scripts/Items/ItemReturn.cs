using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemReturn : TemporaryMonoBehaviourSingleton<ItemReturn>
{
    public List<GameObject> pieceCollect = new List<GameObject>();
    // create list of piece positions
    public List<Vector3> piecePositions = new List<Vector3>();
    // create list of piece positions in dashboard
    public List<Position> piecePositionsDashboard = new List<Position>();
    public void AddInfoPiece(PieceItemHandler piece)
    {
        pieceCollect.Add(piece.gameObject);
        piecePositions.Add(piece.transform.position);
        piecePositionsDashboard.Add(piece.Model.Position);

    }
    public void Clear(PieceItemHandler piece)
    {
        pieceCollect.Remove(piece.gameObject);
        piecePositions.Remove(piece.transform.position);
        piecePositionsDashboard.Remove(piece.Model.Position);
    }
}
