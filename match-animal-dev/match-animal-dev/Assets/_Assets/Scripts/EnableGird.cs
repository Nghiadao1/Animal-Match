using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableGird : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup girdLayoutGroup;
    void Awake()
    {
        Init();
        Invoke("DisableGirdLayoutGroup", 0.5f);
    }
    public void Init()
    {
        girdLayoutGroup = GetComponent<GridLayoutGroup>();
    }
    public void DisableGirdLayoutGroup()
    {
        girdLayoutGroup.enabled = false;
    }
    public void EnableGirdLayoutGroup()
    {
        girdLayoutGroup.enabled = true;
    }
    public void Restart()
    {
        EnableGirdLayoutGroup();
        Invoke("DisableGirdLayoutGroup", 0.1f);
    }

}
