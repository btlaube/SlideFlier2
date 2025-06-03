using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonHoldHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private UnityEvent onButtonPressed;
    [SerializeField] private UnityEvent onButtonReleased;

    public void OnPointerDown(PointerEventData eventData)
    {
        onButtonPressed?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onButtonReleased?.Invoke();
    }
}
