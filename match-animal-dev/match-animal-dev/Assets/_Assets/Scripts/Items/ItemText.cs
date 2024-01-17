using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemText : TemporaryMonoBehaviourSingleton<ItemText>
{
    private ItemSpin itemSpin => ItemSpin.Instance;
    public Text goldItemText;
    public Text hintItemText;
    public Text undoItemText;
    public Text shuffleItemText;
    public Text goldStoreText;
    public Text hintStoreText;
    public Text undoStoreText;
    public Text shuffleStoreText;
    public void LoadText()
    {
        LoadTextItem();
        LoadTextStore();
    }
    public void LoadTextItem()
    {
        updateText(goldItemText, itemSpin.gold);
        updateText(hintItemText, itemSpin.hint);
        updateText(undoItemText, itemSpin.undo);
        updateText(shuffleItemText, itemSpin.shuffle);
    }
    public void LoadTextStore()
    {
        updateText(goldStoreText, itemSpin.gold);
        updateText(hintStoreText, itemSpin.hint);
        updateText(undoStoreText, itemSpin.undo);
        updateText(shuffleStoreText, itemSpin.shuffle);
    }
    private void updateText(Text text, int value)
    {
        text.text = value.ToString();
    }
}
