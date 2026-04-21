using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;
using System.Threading.Tasks;

public class MouseInputHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler
{
    [SerializeField] private UnityEvent onMouseLeftClick;
    [SerializeField] private UnityEvent onMouseMiddleClick;
    [SerializeField] private UnityEvent onMouseRightClick;

    public Image fadePanel;

    private async void OnButtonClick()
    {
        fadePanel.DOFade(0.5f, 0.1f);
        await Task.Delay(250);
        fadePanel.DOFade(1f, 0.1f);
    }
    private void OnButtonDown()
    {
        fadePanel.DOFade(0.5f, 0.1f);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //Debug.Log("Left click");
            onMouseLeftClick?.Invoke();
            OnButtonClick();
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
           // Debug.Log("Middle click");
            onMouseMiddleClick?.Invoke();
            eventData.Reset();
            OnButtonClick();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            //Debug.Log("Right click");
            onMouseRightClick?.Invoke();
            eventData.Reset();
            OnButtonClick();
        }
    }

    public void ActiveOnLeft()
    {
        //Debug.Log("ActiveOnLeft");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Клавиша зажата");
        OnButtonDown();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Курсор навелся");
    }
}