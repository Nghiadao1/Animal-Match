using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class DaiLyReward : MonoBehaviour
{
    public Text dayText;
    public Text coinText;
    public GameObject collectedImage;
    [SerializeField] private int day;
    [SerializeField] private int coin;
    [SerializeField] public bool isCanCollect;
    void Start()
    {
        Init();
    }

    private void Init()
    {
        if (this.day <= DataDailyReward.DayNow()) collectedImage.SetActive(true);
        else collectedImage.SetActive(false);
    }

    public void SetData(int day, int coin, bool isCollected)
    {
        Data(day, coin, isCollected);
        Views(day, coin, isCollected);
    }

    private void Views(int day, int coin, bool isCollected)
    {
        dayText.text = "Day " + day;
        coinText.text = coin.ToString();
        collectedImage.SetActive(isCollected);
    }

    private void Data(int day, int coin, bool isCollected)
    {
        this.day = day;
        this.coin = coin;
        this.isCanCollect = !isCollected;
    }
    public void CollectReward()
    {
        if (isCanCollect)
        {
            Collect();
            Invoke("HidePanelDailyReward", 0.5f);
        }
    }
    private void HidePanelDailyReward()
    {
        PanelManager.Instance.HidePanelDailyReward();
    }
    private void SaveData()
    {
        DatabaseManager.SaveData<int>(DatabaseManager.DatabaseKey.Day, day);
    }

    private void Collect()
    {
        isCanCollect = false;
        SaveData();
        collectedImage.SetActive(true);
        if (!isCanCollect) SetInteractable();
        ItemSpin.Instance.gold += coin;
        ItemSpin.Instance.SetDataValues();
        DataDailyReward.Instance.DayCanCollect();
    }

    private void SetInteractable()
    {
        this.GetComponent<Button>().interactable = false;
    }
}
