using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    public int stepThisLayer = 0;
    public int stepNextLayer = 0;
    [SerializeField] private float StepRow;
    [SerializeField] private float StepCol;
    private PieceItemManager PieceItemManager => PieceItemManager.Instance;
    public void IntanceGroup(int stepNumber, int nextStep, Transform pos)
    {
        stepThisLayer = stepNumber;
        stepNextLayer = nextStep;
        var layer = Instantiate(this, pos.transform.position + new Vector3(stepThisLayer * StepCol, stepThisLayer * StepRow, 0), Quaternion.identity);
        layer.transform.SetParent(GameObject.Find("-----GameVIew-----").transform);
        var content = layer.transform.Find("Viewport/Content");
        PieceItemManager.pieceItemRoots.Add(content);
    }
    public void SetStepLayer(int step)
    {

    }
}
