using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItemScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startTransform;
    private PlayerController controller;

    private void Start()
    {
        controller = GameObject.Find("WorkshopCam").GetComponent<PlayerController>();
    }

    void Awake()
    {
        startTransform = transform.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        controller.dragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        controller.dragging = true;
        RaycastHit hit;
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out hit) && hit.transform.tag == "Hole")
        {
            Destroy(hit.transform.gameObject);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        controller.dragging = false;
        transform.position = startTransform;
    }
}
