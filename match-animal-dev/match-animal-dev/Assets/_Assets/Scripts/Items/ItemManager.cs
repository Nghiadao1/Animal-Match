using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : TemporaryMonoBehaviourSingleton<ItemManager>
{
    private ItemReturn itemReturn => ItemReturn.Instance;

    public void AddInfoPiece(PieceItemHandler piece)
    {
        itemReturn.AddInfoPiece(piece);
    }

    public void ReturnItem()
    {
        for (int i = 0; i < itemReturn.pieceCollect.Count; i++)
        {
            itemReturn.pieceCollect[i].transform.position = itemReturn.piecePositions[i];
            itemReturn.pieceCollect[i].GetComponent<PieceItemHandler>().Model.Position = itemReturn.piecePositionsDashboard[i];
            //return piece gameobject to piece layer
            itemReturn.pieceCollect[i].transform.parent = PieceItemManager.Instance.pieceItemRoots[itemReturn.pieceCollect[i].GetComponent<PieceItemHandler>().layerPiece - 1];
            //return piece to piece board
            PieceItemManager.Instance.PieceBoard[itemReturn.pieceCollect[i].GetComponent<PieceItemHandler>().Model.Position.Row, itemReturn.pieceCollect[i].GetComponent<PieceItemHandler>().Model.Position.Column] = itemReturn.pieceCollect[i].GetComponent<PieceItemHandler>();
            // var piece = itemReturn.pieceCollect[i];
            // piece.SetActive(true);
        }
        Clear();
    }
    public void Clear()
    {
        itemReturn.pieceCollect.Clear();
        itemReturn.piecePositions.Clear();
        itemReturn.piecePositionsDashboard.Clear();
    }
}
