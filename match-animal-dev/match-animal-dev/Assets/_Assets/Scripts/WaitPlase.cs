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
    public GameObject piece;
    public Image imagePiece;
    void Start()
    {
        place = gameObject;
    }
    void Update()
    {
        CheckHavePieceWait();
    }

    private void CheckHavePieceWait()
    {
        SetViewPieceWaitline();
    }

    private void SetViewPieceWaitline()
    {
        foreach (Transform child in place.transform)
        {
            if (child.gameObject.tag == "Piece")
            {
                piece.SetActive(true);
                //child.gameObject.SetActive(false);
            }
            else piece.SetActive(false);
        }
    }

    public void PutOn(PieceItemHandler pieceItems)
    {
        this.pieceItem = pieceItems;
        DotweenMovePiece(pieceItems);
        GetPieceWait(pieceItems);
    }
    public void DotweenMovePiece(PieceItemHandler pieceItems)
    {
        pieceItems.transform.DOMove(position, 0.5f).SetEase(Ease.Flash).OnComplete(() =>
        {
            pieceItems.transform.position = position;
            pieceItems.transform.SetParent(place.transform);
            //pieceItems.gameObject.SetActive(false);
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
    public void GetPieceWait(PieceItemHandler pieceItem)
    {
        imagePiece.sprite = pieceItem.pieceIconImage.sprite;
    }
    public void RemovePiece()
    {
        this.pieceItem = null;
    }
}
