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
    public void IntanceGroup(int stepNumber, int nextStep, Transform pos)
    {
        SetUpLayer(stepNumber, nextStep);
        LayerController layer = CreateLayer(pos);
        SetUpInfoLayer(layer);
    }

    private void SetUpInfoLayer(LayerController layer)
    {
        var content = layer.transform.Find("Viewport/Content");
        PieceItemManager.pieceItemRoots.Add(content);
        thisLayer = PieceItemManager.pieceItemRoots.IndexOf(content) + 1;
        layer.transform.localScale = new Vector3(1, 1, 1);
    }

    private LayerController CreateLayer(Transform pos)
    {
        var layer = Instantiate(this, pos.transform.position + new Vector3(stepThisLayer * StepCol, stepThisLayer * StepRow, 0), Quaternion.identity);
        PieceItemManager.layerControllers.Add(layer);
        layer.transform.SetParent(GameObject.Find("-----GameVIew-----").transform);
        layer.GetComponent<RectTransform>().sizeDelta = this.GetComponent<RectTransform>().sizeDelta;
        return layer;
    }

    private void SetUpLayer(int stepNumber, int nextStep)
    {
        stepThisLayer = stepNumber;
        if (nextStep > 0) stepNextLayer = 1;
        else if (nextStep < 0) stepNextLayer = -1;
    }
}
