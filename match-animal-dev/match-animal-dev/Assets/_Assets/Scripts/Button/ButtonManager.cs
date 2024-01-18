using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private PanelManager PanelManager => PanelManager.Instance;
    private PieceItemManager PieceItemManager => PieceItemManager.Instance;
    private ItemManager ItemManager => ItemManager.Instance;
    private GameManager GameManager => GameManager.Instance;
    public void ButtonNextLevel()
    {
        PanelManager.HideAllPanel();
        PanelManager.ShowPanelLoading();
        Invoke("NextLevel", 1f);
    }

    private void NextLevel()
    {
        GameManager.NextLevel();
    }

    public void ButtonRestart()
    {
        PanelManager.HidePanelSetting();
        PanelManager.ShowPanelLoading();
        Invoke("Restart", 1f);
    }

    private void Restart()
    {
        GameManager.Restart();
        PieceItemManager.InitPieceLayer();
        PieceItemManager.RestartLayer();
        ItemManager.Shuffle();
    }

    public void ButtonContinue()
    {
        PanelManager.HidePanelLose();
        Continue();
    }

    private void Continue()
    {
        ItemManager.Return();
        StartCoroutine(ContinueShuffle());
    }

    public IEnumerator ContinueShuffle()
    {
        yield return new WaitForSeconds(1f);
        ItemManager.ShuffleItem();
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
    public void ButtonOpenHomeScene()
    {
        PanelManager.HideAllPanel();
        PanelManager.ShowPanelHomeScene();
    }
    public void ButtonCloseHomeScene()
    {
        PanelManager.HidePanelHomeScene();
        PanelManager.ShowPanelLoading();
        ButtonRestart();
    }
    public void ButtonOpenLose()
    {
        PanelManager.ShowPanelLose();
    }
    public void ButtonCloseLose()
    {
        PanelManager.HidePanelLose();
    }
    public void ButtonOpenWin()
    {
        PanelManager.ShowPanelWin();
    }
    public void ButtonCloseWin()
    {
        PanelManager.HidePanelWin();
    }
}
