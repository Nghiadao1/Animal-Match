using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDailyReward : TemporaryMonoBehaviourSingleton<DataDailyReward>
{
    public List<DaiLyReward> dailyRewards;
    private int day = 0;
    private int coin = 50;
    void Start()
    {
        Init();
        AddListDailyReward();
        SetData();
        DayCanCollect();
    }
    private void Init()
    {
        dailyRewards = new List<DaiLyReward>();
    }

    private void AddListDailyReward()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            dailyRewards.Add(transform.GetChild(i).GetComponent<DaiLyReward>());
        }
    }

    private void SetData()
    {
        for (int i = 0; i < dailyRewards.Count; i++)
        {
            dailyRewards[i].SetData(day + 1, coin + 50, false);
            day++;
            coin += 50;
        }
    }
    public void DayCanCollect()
    {
        for (int i = 0; i < dailyRewards.Count; i++)
        {
            if (i == DayNow()) dailyRewards[i].isCanCollect = true;
            else dailyRewards[i].isCanCollect = false;
        }
    }

    public static int DayNow()
    {
        return DatabaseManager.LoadData<int>(DatabaseManager.DatabaseKey.Day);
    }
}
