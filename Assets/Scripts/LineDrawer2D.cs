using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer2D : MonoBehaviour
{
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private Transform players;
    [SerializeField] private GameObject PathParent;
    [SerializeField] private SplineComputer currentSpline;
    [SerializeField] private MousePositionHandler mousePositionHandler;
    [SerializeField] private LayerMask _uiMask;
    [SerializeField] private LineTransmitter _transmitter;
    [SerializeField] private PlayerHolder playerHolder;

    private Camera _camera;
    private Line activeLine;
    private Line previousLine;

    private void Awake()
    {
        mousePositionHandler.OnPointerDownEvent += StartDraw;
        mousePositionHandler.OnPointerUpEvent += EndDraw;
        mousePositionHandler.OnPointerMovedEvent += MoveBrush;
        _camera = Camera.main;
    }

    private void MoveBrush(Vector2 vector)
    {
        if (activeLine != null && mousePositionHandler.IsPointerDown)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out var hit, 100f, _uiMask))
            {
                //Debug.Log(hit.point);
                activeLine.UpdateLine(hit.point, PathParent.transform);
                return;
            }
        }
    }

    private void EndDraw()
    {
        if (previousLine != null)
        {
            Destroy(previousLine.gameObject);
        }

        previousLine = activeLine;
        //currentSpline = activeLine.splineComputer;
        _transmitter.UpdatePath(activeLine.splineComputer);
        activeLine = null;
    }

    private void StartDraw()
    {
        GameObject newLine = Instantiate(linePrefab, PathParent.transform);
        activeLine = newLine.GetComponent<Line>();
    }
}
