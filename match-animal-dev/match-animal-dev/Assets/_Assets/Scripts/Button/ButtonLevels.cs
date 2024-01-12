using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevels : MonoBehaviour
{
    public Text textLevel;
    public bool isLock;
    public GameObject lockLevel;
    // Start is called before the first frame update
    public int _level;
    private Levels Levels => Levels.Instance;
    void Start()
    {
        Init();
    }
    public void Init()
    {
        SetTextLevel();
    }

    private void SetTextLevel()
    {
        _level = Levels.levels.IndexOf(gameObject) + 1;
        textLevel.text = _level.ToString();
    }
    void Update()
    {
        SetLock();
        CheckLock();
    }
    private void SetLock()
    {
        if (_level <= GameManager.Instance.Level) isLock = false;
        else isLock = true;
    }
    private void CheckLock()
    {
        if (IsLock()) lockLevel.SetActive(true);
        else lockLevel.SetActive(false);
    }

    private bool IsLock()
    {
        return isLock;
    }
}
