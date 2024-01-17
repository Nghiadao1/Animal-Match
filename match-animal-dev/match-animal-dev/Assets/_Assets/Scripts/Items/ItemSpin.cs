using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
public class ItemSpin : TemporaryMonoBehaviourSingleton<ItemSpin>
{
    private ItemText itemText => ItemText.Instance;
    public GameObject wheelContent;
    public Text goldText;
    public Text hintText;
    public Text undoText;
    public Text shuffleText;
    public int gold;
    public int hint;
    public int undo;
    public int shuffle;
    void Start()
    {
        Init();
    }

    private void Init()
    {
        LoadDataItem();
        LoadText();
        itemText.LoadText();
    }

    public void LoadDataItem()
    {
        gold = DatabaseManager.LoadData<int>(DatabaseManager.DatabaseKey.Gold);
        hint = DatabaseManager.LoadData<int>(DatabaseManager.DatabaseKey.Hint);
        undo = DatabaseManager.LoadData<int>(DatabaseManager.DatabaseKey.Undo);
        shuffle = DatabaseManager.LoadData<int>(DatabaseManager.DatabaseKey.Shuffle);
    }
    public void SaveDataItem()
    {
        DatabaseManager.SaveData<int>(DatabaseManager.DatabaseKey.Gold, gold);
        DatabaseManager.SaveData<int>(DatabaseManager.DatabaseKey.Hint, hint);
        DatabaseManager.SaveData<int>(DatabaseManager.DatabaseKey.Undo, undo);
        DatabaseManager.SaveData<int>(DatabaseManager.DatabaseKey.Shuffle, shuffle);
    }

    public void Spin()
    {
        float randomZ = Random.Range(1080f, 1440f);
        wheelContent.transform.DOLocalRotate(new Vector3(0, 0, randomZ), 2f, RotateMode.FastBeyond360).SetEase(Ease.OutCubic).OnComplete(() =>
        {
            RewardItemSpin(randomZ);
            SetDataValues();
        });
    }

    public void SetDataValues()
    {
        SaveDataItem();
        LoadDataItem();
        LoadText();
        itemText.LoadText();

    }

    public void LoadText()
    {
        updateText(goldText, gold);
        updateText(hintText, hint);
        updateText(undoText, undo);
        updateText(shuffleText, shuffle);
    }

    public void RewardItemSpin(float value)
    {
        // follow of result randomZ, i want with 45f index increase from 1080. Gold = 0, Hint = 1, Undo = 2, Shuffle = 3
        if (value >= 1080f && value < 1125f - 22.5f) shuffle++;
        else if (value >= 1125f && value < 1170f - 22.5f) gold += 150;
        else if (value >= 1170f - 22.5f && value < 1215f - 22.5f) hint += 2;
        else if (value >= 1215f - 22.5f && value < 1260f - 22.5f) undo += 2;
        else if (value >= 1260f - 22.5f && value < 1305f - 22.5f) shuffle += 2;
        else if (value >= 1305f - 22.5f && value < 1350f - 22.5f) gold += 300;
        else if (value >= 1350f - 22.5f && value < 1395f - 22.5f) hint++;
        else if (value >= 1395f - 22.5f && value < 1440f - 22.5f) undo++;
        else shuffle++;

    }
    public void updateText(Text text, int value)
    {
        text.text = value.ToString();
    }
}
