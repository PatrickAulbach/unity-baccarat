using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler 
{
    [SerializeField] KindOfBet kindOfBet;
    private MultipleDropHandler dropHandler;
    private Vector2 anchoredPosition;

    private void Start() 
    {
        dropHandler = GameObject.Find("DropHandler").GetComponent<MultipleDropHandler>();
        anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
    }

    public void OnDrop(PointerEventData eventData) 
    {
        if (eventData.pointerDrag != null) {
            var chip = eventData.pointerDrag.GetComponent<Chip>();
            chip.dropZone = this;
            AddChip(chip);
        }
    }

    private void AddChip(Chip chip)
    {
        dropHandler.AddChip(kindOfBet, chip);
    }
    public void RemoveChip(Chip chip)
    {
        dropHandler.RemoveChip(kindOfBet, chip);
    }

}
