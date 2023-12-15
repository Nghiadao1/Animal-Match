using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;
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
        if (place.transform.GetChild(0).gameObject.CompareTag("Piece")) piece.SetActive(true);
        else piece.SetActive(false);
    }

    public void PutOn(PieceItemHandler pieceItems)
    {
        this.pieceItem = pieceItems;
        pieceItems.transform.position = position;
        pieceItems.transform.SetParent(place.transform);
        GetPieceWait(pieceItems);
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
