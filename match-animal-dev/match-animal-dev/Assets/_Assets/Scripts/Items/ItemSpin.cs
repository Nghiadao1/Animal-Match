using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class ItemSpin : TemporaryMonoBehaviourSingleton<ItemSpin>
{
    public GameObject wheelContent;
    public void Spin()
    {
        float randomZ = Random.Range(3000f, 4000f);
        wheelContent.transform.DOLocalRotate(new Vector3(0, 0, randomZ), 2f, RotateMode.FastBeyond360).SetEase(Ease.OutCubic);
    }
}
