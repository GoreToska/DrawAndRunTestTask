using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(SplineRenderer))]
public class Spline : MonoBehaviour
{
    [SerializeField] private float _distanceThreshold;

    private SplineRenderer _splineRenderer;
    private SplineComputer splineComputer;
    private List<SplinePoint> points;

    private void Awake()
    {
        splineComputer = GetComponent<SplineComputer>();
    }

    public void UpdateSpline(Vector3 point)
    {
        if (points == null)
        {
            points = new List<SplinePoint>();
            SetPoint(point);

            return;
        }

        if (Vector2.Distance(new Vector2(points.Last().position.x, points.Last().position.z), point) > _distanceThreshold)
        {
            SetPoint(point);
        }
    }

    private void SetPoint(Vector3 point)
    {
        var newPoint = new SplinePoint(new Vector3(point.x, 0, point.z));
        points.Add(newPoint);
        Debug.Log($"Adding {newPoint.position}");
        // add visual

        splineComputer.SetPoint(points.Count - 1, newPoint);
    }

    public SplinePoint[] GetPoints()
    {
        return splineComputer.GetPoints();
    }
}
