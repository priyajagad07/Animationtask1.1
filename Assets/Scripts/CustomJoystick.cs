using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform background;
    public RectTransform handle;

    public float maxDistance = 5f;
    public Vector2 inputDIrection;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background,
            eventData.position,
            eventData.pressEventCamera,
            out pos
        );

        pos = Vector2.ClampMagnitude(pos, maxDistance);
        handle.anchoredPosition = pos;
        inputDIrection = pos / maxDistance;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        handle.anchoredPosition = Vector2.zero;
        inputDIrection = Vector2.zero;
    }
}


