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
    public void LoadText()
    {
        updateText(goldItemText, itemSpin.gold);
        updateText(hintItemText, itemSpin.hint);
        updateText(undoItemText, itemSpin.undo);
        updateText(shuffleItemText, itemSpin.shuffle);
    }
    private void updateText(Text text, int value)
    {
        text.text = value.ToString();
    }
}
