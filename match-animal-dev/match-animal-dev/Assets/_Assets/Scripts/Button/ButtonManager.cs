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
        PanelManager.HideAllPanel();
    }
    public void ButtonContinue()
    {
        // GameManager.Instance.Reverse();
        PanelManager.HidePanelLose();
    }
    public void ButtonOpenSetting()
    {
        PanelManager.ShowPanelSetting();
    }
    public void ButtonResume()
    {
        PanelManager.HidePanelSetting();
    }
    public void ButtonOpenLevelMenu()
    {
        PanelManager.ShowPanelLevelMenu();
    }
    public void ButtonCloseLevelMenu()
    {
        PanelManager.HidePanelLevelMenu();
    }
    public void ButtonOpenStore()
    {
        PanelManager.ShowPanelStore();
    }
    public void ButtonCloseStore()
    {
        PanelManager.HidePanelStore();
    }
    public void ButtonOpenLanguage()
    {
        PanelManager.ShowPanelLanguage();
    }
    public void ButtonCloseLanguage()
    {
        PanelManager.HidePanelLanguage();
    }
    public void ButtonOpenADs()
    {
        PanelManager.ShowPanelADs();
    }
    public void ButtonCloseADs()
    {
        PanelManager.HidePanelADs();
    }
    public void ButtonOpenRatting()
    {
        PanelManager.ShowPanelRatting();
    }
    public void ButtonCloseRatting()
    {
        PanelManager.HidePanelRatting();
    }
    public void ButtonOpenNotify()
    {
        PanelManager.ShowPanelNotify();
    }
    public void ButtonCloseNotify()
    {
        PanelManager.HidePanelNotify();
    }

    public void ButtonOpenOutOfCoin()
    {
        PanelManager.ShowPanelOutOfCoin();
    }
    public void ButtonCloseOutOfCoin()
    {
        PanelManager.HidePanelOutOfCoin();
    }
    public void ButtonOpenTutorial()
    {
        PanelManager.ShowPanelTutorial();
    }
    public void ButtonCloseTutorial()
    {
        PanelManager.HidePanelTutorial();
    }
    public void ButtonOpenLuckySpin()
    {
        PanelManager.ShowPanelLuckySpin();
    }
    public void ButtonCloseLuckySpin()
    {
        PanelManager.HidePanelLuckySpin();
    }
    public void ButtonOpenDailyGift()
    {
        PanelManager.ShowPanelDailyReward();
    }
    public void ButtonCloseDailyGift()
    {
        PanelManager.HidePanelDailyReward();
    }
}
