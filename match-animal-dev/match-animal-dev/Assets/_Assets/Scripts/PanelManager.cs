using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : TemporaryMonoBehaviourSingleton<PanelManager>
{
    public GameObject panelWin;
    public GameObject panelLose;
    public GameObject panelSetting;
    public GameObject panelLevelMenu;
    public GameObject panelStore;
    public GameObject panelLanguage;
    public GameObject panelADs;
    public GameObject panelRatting;
    public GameObject panelNotify;
    public GameObject panelOutOfCoin;
    public GameObject panelTutorial;
    public GameObject panelLuckySpin;
    public GameObject panelDailyReward;

    public void ShowPanelDailyReward()
    {
        panelDailyReward.SetActive(true);
    }
    public void HidePanelDailyReward()
    {
        panelDailyReward.SetActive(false);
    }

    public void ShowPanelLuckySpin()
    {
        panelLuckySpin.SetActive(true);
    }
    public void HidePanelLuckySpin()
    {
        panelLuckySpin.SetActive(false);
    }

    public void ShowPanelTutorial()
    {
        panelTutorial.SetActive(true);
    }
    public void HidePanelTutorial()
    {
        panelTutorial.SetActive(false);
    }

    public void ShowPanelOutOfCoin()
    {
        panelOutOfCoin.SetActive(true);
    }
    public void HidePanelOutOfCoin()
    {
        panelOutOfCoin.SetActive(false);
    }

    public void ShowPanelNotify()
    {
        panelNotify.SetActive(true);
    }
    public void HidePanelNotify()
    {
        panelNotify.SetActive(false);
    }

    public void ShowPanelRatting()
    {
        panelRatting.SetActive(true);
    }
    public void HidePanelRatting()
    {
        panelRatting.SetActive(false);
    }

    public void ShowPanelADs()
    {
        panelADs.SetActive(true);
    }
    public void HidePanelADs()
    {
        panelADs.SetActive(false);
    }
    public void ShowPanelLanguage()
    {
        panelLanguage.SetActive(true);
    }
    public void HidePanelLanguage()
    {
        panelLanguage.SetActive(false);
    }
    public void ShowPanelStore()
    {
        panelStore.SetActive(true);
    }
    public void HidePanelStore()
    {
        panelStore.SetActive(false);
    }
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
    public void ShowPanelSetting()
    {
        panelSetting.SetActive(true);
    }
    public void HidePanelSetting()
    {
        panelSetting.SetActive(false);
    }
    public void ShowPanelLevelMenu()
    {
        panelLevelMenu.SetActive(true);
    }
    public void HidePanelLevelMenu()
    {
        panelLevelMenu.SetActive(false);
    }
    public void HideAllPanel()
    {
        panelWin.SetActive(false);
        panelLose.SetActive(false);
        panelSetting.SetActive(false);
    }
}
