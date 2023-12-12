using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    public int thisLayer = 0;
    public int stepThisLayer = 0;
    public int stepNextLayer = 0;
    [SerializeField] private float StepRow;
    [SerializeField] private float StepCol;
    private PieceItemManager PieceItemManager => PieceItemManager.Instance;
    void Start()
    {
        Init();
    }
    private void Init()
    {
        //update thisLayer = index of this content in PieceItemRoots
    }
    public void IntanceGroup(int stepNumber, int nextStep, Transform pos)
    {
        stepThisLayer = stepNumber;
        stepNextLayer = nextStep;
        var layer = Instantiate(this, pos.transform.position + new Vector3(stepThisLayer * StepCol * thisLayer, stepThisLayer * StepRow * thisLayer, 0), Quaternion.identity);
        layer.transform.SetParent(GameObject.Find("-----GameVIew-----").transform);
        var content = layer.transform.Find("Viewport/Content");
        PieceItemManager.pieceItemRoots.Add(content);
        //get index of this content in PieceItemRoots
        thisLayer = PieceItemManager.pieceItemRoots.IndexOf(content) + 1;

    }
}
