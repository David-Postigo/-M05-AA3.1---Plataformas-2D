using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public bool esSlotEquipado = false;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dragged = eventData.pointerDrag;

        if (dragged == null)
            return;

        Transform item = dragged.transform;

        if (esSlotEquipado)
        {
            if (transform.childCount > 0)
                return;
        }
        else
        {
            if (transform.childCount > 0)
                return;
        }

        item.SetParent(transform);
        item.localPosition = Vector3.zero;
    }
}