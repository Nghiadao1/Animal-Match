using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemShuffle : TemporaryMonoBehaviourSingleton<ItemShuffle>
{
    PieceItemManager PieceItemManager => PieceItemManager.Instance;
    public void ShufflePiece()
    {
        //get rabdom 2 piece in pieceItemHandlers and swap position and data in dashboard
        for (int i = 0; i < PieceItemManager.PieceItemHandlers.Count; i++)
        {
            var random1 = Random.Range(0, PieceItemManager.PieceItemHandlers.Count);
            var random2 = Random.Range(0, PieceItemManager.PieceItemHandlers.Count);
            var piece1 = PieceItemManager.PieceItemHandlers[random1];
            var piece2 = PieceItemManager.PieceItemHandlers[random2];
            var temp = piece1.Model;
            piece1.SetData(piece2.Model);
            piece2.SetData(temp);
            var tempPosition = piece1.Model.Position;
            piece1.Model.Position = piece2.Model.Position;
            piece2.Model.Position = tempPosition;
        }

    }
}
