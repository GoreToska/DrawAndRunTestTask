using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] public SplineComputer splineComputer;
    [SerializeField] private float distance;
    List<Vector3> points;

    public void UpdateLine(Vector3 position, Transform parent)
    {
        if(points == null)
        {
            points = new List<Vector3>();
            SetPoint(position, parent);
            return;
        }

        if(Vector3.Distance(points.Last(), position) > distance)
        {
            SetPoint(position, parent);
        }
    }

    private void SetPoint(Vector3 point, Transform parent)
    {
        points.Add(point);

        //var localVector = parent.InverseTransformPoint(new Vector3(point.x, 0, point.y));

        var splinePoint = new SplinePoint(point);
        splineComputer.SetPoint(points.Count-1, splinePoint);
    }


}
