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
        Debug.Log("ReturnItem");
        itemReturn.UndoPiece();
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
