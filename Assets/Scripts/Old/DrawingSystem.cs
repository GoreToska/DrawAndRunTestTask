using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawingSystem : MonoBehaviour
{
    [field: SerializeField] public SplineComputer PathSpline { get; private set; }
    [SerializeField] private GameObject _splinePrefab;
    [SerializeField] private GameObject _splinesParent;
    //[SerializeField] private MousePositionHandler _mousePositionHandler;

    private Camera _camera;
    private GameObject _currentSpline;
    private Spline _drawingSpline;

    private void Awake()
    {
        _camera = Camera.main;
        //_mousePositionHandler.OnPointerMovedEvent += DrawNewSpline;
        //_mousePositionHandler.OnPointerDownEvent += StartDraw;
        //_mousePositionHandler.OnPointerUpEvent += EndDraw;
    }

    private void Update()
    {
        DrawNewSpline();
    }

    public void DrawNewSpline()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartDraw();
        }

        if(Input.GetMouseButtonUp(0))
        {
            EndDraw();
        }

        if (_drawingSpline != null)
        {
            var position = _camera.ScreenToViewportPoint(Input.mousePosition);
            Debug.Log(position);
            _drawingSpline.UpdateSpline(position);
        }
    }

    public void StartDraw()
    {
        Debug.Log("Draw!");
        var newSpline = Instantiate(_splinePrefab, _splinesParent.transform);
        _drawingSpline = newSpline.GetComponent<Spline>();
    }

    public void EndDraw()
    {
        Destroy(_currentSpline);
        PathSpline.SetPoints(_drawingSpline.GetPoints());
        //Destroy(_drawingSpline.gameObject);
        _drawingSpline = null;
    }
}
