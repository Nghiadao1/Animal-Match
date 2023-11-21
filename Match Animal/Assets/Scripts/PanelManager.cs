using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject Win;
    public GameObject Lose;
    public void EnablePanelWin(){
        Win.SetActive(true);
    }
    public void EnablePanelLose(){
        Lose.SetActive(true);
    }
    public void DisablePanelWin(){
        Win.SetActive(false);
    }
    public void DisablePanelLose(){
        Lose.SetActive(false);
    }
    
}
