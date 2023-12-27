using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHint : TemporaryMonoBehaviourSingleton<ItemHint>
{
    PieceItemManager PieceItemManager => PieceItemManager.Instance;
    WaitLine WaitLine => WaitLine.Instance;
    public void HintPiece()
    {
        //in list piece item handler find 3 piece item handler same type and addPiece
        PieceItemManager.FindPieceSameType();
    }
}
