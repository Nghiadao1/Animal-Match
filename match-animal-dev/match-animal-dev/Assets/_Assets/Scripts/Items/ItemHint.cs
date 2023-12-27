using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHint : TemporaryMonoBehaviourSingleton<ItemHint>
{
    PieceItemManager PieceItemManager => PieceItemManager.Instance;
    WaitLine WaitLine => WaitLine.Instance;
    public void HintPiece()
    {
        PieceItemManager.FindPieceSameType();
    }

}
