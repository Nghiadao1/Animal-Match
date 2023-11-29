using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class WaitPlase : MonoBehaviour
{
    public GameObject place;
    [SerializeField] private PieceItemHandler pieceItem;
    public Vector3 position => place.transform.position;
    void Start()
    {
        place = gameObject;
    }
    public void PutOn(PieceItemHandler pieceItem)
    {
        this.pieceItem = pieceItem;
        pieceItem.transform.position = position;
        pieceItem.transform.SetParent(place.transform);
    }
    public void Empty()
    {
        Destroy(pieceItem.gameObject, 1f);
        pieceItem = null;
    }
}
