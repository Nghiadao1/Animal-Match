using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPSystem : MonoBehaviour
{
    private ItemSpin itemSpin => ItemSpin.Instance;
    public void OnPurchaseCompleted(int index)
    {
        itemSpin.gold += 400 * index;
        itemSpin.hint += index;
        itemSpin.undo += index;
        itemSpin.shuffle += index;
        itemSpin.SetDataValues();
    }
    public void OnPuchaseGoldCompleted(int gold)
    {
        itemSpin.gold += gold;
        itemSpin.SetDataValues();
    }
    public void OnPurchaseFailed()
    {
        Debug.Log("Purchase failed");
    }
    public void OnProductFetched()
    {
        Debug.Log("Product fetched");
    }
    public void OnRemoveAdsCompleted()
    {
        Debug.Log("Remove ads completed");
    }
    public void OnTransactionRestore()
    {
        Debug.Log("Transaction restore");
    }
}
