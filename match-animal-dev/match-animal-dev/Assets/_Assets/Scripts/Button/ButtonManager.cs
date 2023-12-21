using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private PanelManager PanelManager => PanelManager.Instance;
    private PieceItemManager PieceItemManager => PieceItemManager.Instance;
    public void ButtonRestart()
    {

        GameManager.Instance.Restart();
        PieceItemManager.InitPieceLayer();
        PieceItemManager.RestartLayer();
        PanelManager.HidePanelLose();

    }
}
