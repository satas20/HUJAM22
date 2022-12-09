using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLine : MonoBehaviour
{
    [SerializeField] LineRenderer lr;
    [SerializeField] DragAndThrow dragAndThrow;

    private void Awake()
    {
        dragAndThrow = GetComponent<DragAndThrow>();
        lr = GetComponent<LineRenderer>();
    }
    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        if (dragAndThrow.fuel == 0){
            lr.startColor = Color.red;
        }
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;

        lr.SetPositions(points);
    }
    public void EndLine(){
        lr.positionCount = 0;
    }
}
