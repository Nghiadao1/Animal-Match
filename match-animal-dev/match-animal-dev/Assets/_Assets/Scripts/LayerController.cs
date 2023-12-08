using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    public int stepLayer;
    [SerializeField] private float stepRow;
    [SerializeField] private float stepCol;
    private float StepRow => stepRow * 30f;
    private float StepCol => stepCol * 30f;
    private PieceItemManager PieceItemManager => PieceItemManager.Instance;
    public void IntanceGroup(int stepNumber)
    {
        stepLayer = stepNumber;
        var layer = Instantiate(this, transform.position + new Vector3(stepNumber * StepCol, stepNumber * StepRow, 0), Quaternion.identity);
        layer.transform.SetParent(GameObject.Find("-----GameVIew-----").transform);
        var content = layer.transform.Find("Viewport/Content");
        PieceItemManager.pieceItemRoots.Add(content);
    }
}
