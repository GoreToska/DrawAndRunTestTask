using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingSystem2D : MonoBehaviour
{
    [field: SerializeField] public SplineComputer PathSpline { get; private set; }
    [SerializeField] private GameObject _splinePrefab;
    [SerializeField] private GameObject _splinesParent;
    [SerializeField] private MousePositionHandler _mousePositionHandler;

    private Camera _camera;
    private GameObject _currentSpline;
    private Spline _drawingSpline;

    private void Awake()
    {
        _camera = Camera.main;
        _mousePositionHandler.OnPointerMovedEvent += DrawNewSpline;
        _mousePositionHandler.OnPointerDownEvent += StartDraw;
        _mousePositionHandler.OnPointerUpEvent += EndDraw;
    }

    public void DrawNewSpline(Vector2 position)
    {

        if (_drawingSpline != null && _mousePositionHandler.IsPointerDown)
        {
            //position = _camera.ScreenToPoint(new Vector3(position.x, position.y, 0));
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
