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

        // pieceWait = place.transform.Find("Piece").gameObject;
        //set piece wait = gameobject piece have tag "Piece" is child of piece
        if (pieceItem != null)
            piece.gameObject.SetActive(true);
        else
            piece.gameObject.SetActive(false);
    }
    public void PutOn(PieceItemHandler pieceItems)
    {
        //this.pieceItem = null;
        if (pieceItems != null)
            this.pieceItem = pieceItems;
        else
            this.pieceItem = null;
        pieceItems.transform.position = position;
        pieceItems.transform.SetParent(place.transform);
        // pieceWait = pieceItems.gameObject;
        GetPieceWait(pieceItems);
        // pieceItem.gameObject.SetActive(false);
        //RemovePiece(pieceItem);

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
