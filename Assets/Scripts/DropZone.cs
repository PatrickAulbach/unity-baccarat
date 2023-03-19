using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler 
{
    [SerializeField] KindOfBet kindOfBet;
    MultipleDropHandler dropHandler;

    private void Start() 
    {
        dropHandler = GameObject.Find("DropHandler").GetComponent<MultipleDropHandler>();
    }

    public void OnDrop(PointerEventData eventData) 
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null) {
            var chip = eventData.pointerDrag.GetComponent<Chip>();
            chip.dropZone = this;
            dropHandler.droppedChips[kindOfBet].Add(chip);

            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }

    public void Clear() 
    {
        dropHandler.droppedChips[kindOfBet] = new List<Chip>();  
    }

    public void Remove(Chip chip)
    {
        dropHandler.droppedChips[kindOfBet].Remove(chip);
    }

    public KindOfBet GetKindOfBet()
    {
        return kindOfBet;
    }

    public List<Chip> GetBetAmount()
    {
        return dropHandler.droppedChips[kindOfBet];
    }
}
