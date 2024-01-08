using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MousePositionHandler : MonoBehaviour, IPointerMoveHandler, IPointerUpHandler, IPointerDownHandler
{
    private Vector2 _mousePosition;
    private bool _isPointerDown = false;
    public UnityAction<Vector2> OnPointerMovedEvent = delegate { };
    public UnityAction OnPointerDownEvent = delegate { };
    public UnityAction OnPointerUpEvent = delegate { };

    public bool IsPointerDown => _isPointerDown;
    public Vector2 MousePosition => _mousePosition;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
        OnPointerDownEvent();
        _isPointerDown = true;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        //_mousePosition = eventData.position;
        //var vector = new Vector3(_mousePosition.x, _mousePosition.y, 0);
        //Debug.Log(_mousePosition);
        //_mousePosition = Camera.main.ScreenToWorldPoint(vector);
        OnPointerMovedEvent(_mousePosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up");
        _isPointerDown = false;
        OnPointerUpEvent();
    }
}
