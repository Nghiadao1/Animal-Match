using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableGird : MonoBehaviour
{
    //[SerializeField] private  girdLayoutGroup;
    [SerializeField] private GridLayoutGroup girdLayoutGroup;
    // Start is called before the first frame update
    void Awake()
    {
        Init();
        Invoke("DisableGirdLayoutGroup", 0.25f);
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
        Invoke("DisableGirdLayoutGroup", 0.3f);
    }

}
