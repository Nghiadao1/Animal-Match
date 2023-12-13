using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : TemporaryMonoBehaviourSingleton<PanelManager>
{
    public GameObject panelWin;
    public GameObject panelLose;
    public void ShowPanelWin()
    {
        panelWin.SetActive(true);
    }
    public void HidePanelWin()
    {
        panelWin.SetActive(false);
    }
    public void ShowPanelLose()
    {
        panelLose.SetActive(true);
    }
    public void HidePanelLose()
    {
        panelLose.SetActive(false);
    }

}
