using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHint : TemporaryMonoBehaviourSingleton<ItemHint>
{
    PieceItemManager PieceItemManager => PieceItemManager.Instance;
    public void HintPiece()
    {
        PieceItemManager.FindPieceSameType();
    }

}
