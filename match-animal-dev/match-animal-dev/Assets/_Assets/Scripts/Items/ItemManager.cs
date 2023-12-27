using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : TemporaryMonoBehaviourSingleton<ItemManager>
{
    private ItemReturn itemReturn => ItemReturn.Instance;
    private ItemHint itemHint => ItemHint.Instance;
    private ItemShuffle itemShuffle => ItemShuffle.Instance;
    public GameObject buttonReverse;
    public GameObject buttonHint;
    public GameObject buttonShuffle;
    public void AddInfoPiece(PieceItemHandler piece)
    {
        itemReturn.AddInfoPiece(piece);
    }

    public void ReturnItem()
    {
        for (int i = 0; i < itemReturn.pieceCollect.Count; i++)
        {
            var piece = itemReturn.pieceCollect[i].GetComponent<PieceItemHandler>();
            itemReturn.pieceCollect[i].transform.position = itemReturn.piecePositions[i];
            piece.Model.Position = itemReturn.piecePositionsDashboard[i];
            //return piece gameobject to piece layer
            itemReturn.pieceCollect[i].transform.parent = PieceItemManager.Instance.pieceItemRoots[piece.layerPiece - 1];
            //return piece to piece board
            PieceItemManager.Instance.PieceBoard[piece.Model.Position.Row, piece.Model.Position.Column] = piece;
            // var piece = itemReturn.pieceCollect[i];
            // piece.SetActive(true);
            itemReturn.pieceCollect.Remove(piece.gameObject);
            itemReturn.piecePositions.Remove(piece.transform.position);
            itemReturn.piecePositionsDashboard.Remove(piece.Model.Position);

        }
    }
    public void HintItem()
    {
        Debug.Log("HintItem");
        itemHint.HintPiece();
        buttonHint.GetComponent<Button>().interactable = false;
        StartCoroutine(HintPieceCoroutine());
    }
    public void ShuffleItem()
    {
        Debug.Log("ShuffleItem");
        itemShuffle.ShufflePiece();
    }
    //coroutine hint piece
    public IEnumerator HintPieceCoroutine()
    {
        yield return new WaitForSeconds(1f);
        buttonHint.GetComponent<Button>().interactable = true;
    }
}
