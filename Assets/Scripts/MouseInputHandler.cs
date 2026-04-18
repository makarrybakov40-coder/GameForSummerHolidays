using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MouseInputHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler
{
    [SerializeField] private UnityEvent onMouseLeftClick;
    [SerializeField] private UnityEvent onMouseMiddleClick;
    [SerializeField] private UnityEvent onMouseRightClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //Debug.Log("Left click");
            onMouseLeftClick?.Invoke();

        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
           // Debug.Log("Middle click");
            onMouseMiddleClick?.Invoke();
            eventData.Reset();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            //Debug.Log("Right click");
            onMouseRightClick?.Invoke();
            eventData.Reset();
        }
    }

    public void ActiveOnLeft()
    {
        //Debug.Log("ActiveOnLeft");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Клавиша зажата");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Курсор навелся");
    }
}