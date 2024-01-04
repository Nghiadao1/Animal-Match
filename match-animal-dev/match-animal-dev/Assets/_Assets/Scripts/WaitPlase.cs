using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;
using DG.Tweening;
[Serializable]
public class WaitPlase : MonoBehaviour
{
    public GameObject place;
    public PieceItemHandler pieceItem;
    public GameObject pieceWait;
    public Vector3 position => place.transform.position;
    void Start()
    {
        place = gameObject;
    }

    public void PutOn(PieceItemHandler pieceItems)
    {
        this.pieceItem = pieceItems;
        DotweenMovePiece(pieceItems);
    }
    public void DotweenMovePiece(PieceItemHandler pieceItems)
    {
        pieceItems.transform.DOMove(position, 0.5f).SetEase(Ease.Flash).OnComplete(() =>
        {
            pieceItems.transform.position = position;
            pieceItems.transform.SetParent(place.transform);
        });
    }
    public void Empty()
    {
        Destroy(pieceItem.gameObject, 1f);
        pieceItem = null;
        Debug.Log("Empty");
    }
    public bool IsEmpty()
    {
        return pieceItem == null;
    }
}
