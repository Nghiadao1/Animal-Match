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

}
