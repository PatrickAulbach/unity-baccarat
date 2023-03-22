using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Chip chip;
    private MultipleDropHandler dropHandler;
    private Transform parentAfterDrag;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        chip = GetComponent<Chip>();
        canvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();
        dropHandler = GameObject.Find("DropHandler").GetComponent<MultipleDropHandler>();

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        dropHandler.DisableRaycast();
        chip.RemoveFromDropZone();
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        transform.SetParent(parentAfterDrag);
        if (chip.dropZone == null)
        {
            chip.Return();
        }
        dropHandler.EnableRaycast();
    }
}