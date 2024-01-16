using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : TemporaryMonoBehaviourSingleton<ItemManager>
{
    private GameManager GameManager => GameManager.Instance;
    private ItemReturn itemReturn => ItemReturn.Instance;
    private ItemHint itemHint => ItemHint.Instance;
    private ItemShuffle itemShuffle => ItemShuffle.Instance;
    private ItemSpin itemSpin => ItemSpin.Instance;
    public GameObject buttonReverse;
    public GameObject buttonHint;
    public GameObject buttonShuffle;
    public void AddInfoPiece(PieceItemHandler piece)
    {
        itemReturn.AddInfoPiece(piece);
    }

    public void ReturnItem()
    {
        if (ItemManagers(itemSpin.undo)) return;
        Debug.Log("ReturnItem");
        StartCoroutine(ReturnCoroutine());
    }
    public IEnumerator ReturnCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        itemReturn.UndoPiece();
        GameManager.OnCheckIsBlocked();
        itemSpin.undo--;
        itemSpin.SetDataValues();
    }
    public void HintItem()
    {
        if (ItemManagers(itemSpin.hint)) return;
        Debug.Log("HintItem");
        itemHint.HintPiece();
        buttonHint.GetComponent<Button>().interactable = false;
        StartCoroutine(HintPieceCoroutine());
    }
    public void ShuffleItem()
    {
        if (ItemManagers(itemSpin.shuffle)) return;
        Debug.Log("ShuffleItem");
        itemShuffle.ShufflePiece();
        itemSpin.shuffle--;
        itemSpin.SetDataValues();
    }
    public IEnumerator HintPieceCoroutine()
    {
        yield return new WaitForSeconds(1f);
        buttonHint.GetComponent<Button>().interactable = true;
        itemSpin.hint--;
        itemSpin.SetDataValues();
    }
    public void SpinItem()
    {
        Debug.Log("SpinItem");
        itemSpin.Spin();
    }
    private bool ItemManagers(int value)
    {
        return value <= 0;
    }

}
