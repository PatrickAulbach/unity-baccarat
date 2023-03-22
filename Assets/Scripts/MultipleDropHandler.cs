using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultipleDropHandler : MonoBehaviour 
{
    [SerializeField] TextMeshProUGUI totalAmountBetText;
    public Dictionary<KindOfBet, List<Chip>> droppedChips;
    private int totalAmountBet;

    private void Start() {
        ResetDroppedChips();
    }

    public void DisableRaycast()
    {
        ProcessChips(false);
    }   

    public void EnableRaycast()
    {
        ProcessChips(true);
    }

    public void RemoveChip(KindOfBet kindOfBet, Chip chip)
    {
        totalAmountBet -= chip.value;
        droppedChips[kindOfBet].Remove(chip);
        ShowTotalAmountBet();
    }

    public void AddChip(KindOfBet kindOfBet, Chip chip)
    {
        totalAmountBet += chip.value;
        droppedChips[kindOfBet].Add(chip);
        ShowTotalAmountBet();
    }

    private void ResetDroppedChips()
    {
        totalAmountBet = 0;
        droppedChips = new Dictionary<KindOfBet, List<Chip>> {
            {KindOfBet.PLAYER, new List<Chip>()},
            {KindOfBet.BANKER, new List<Chip>()},
            {KindOfBet.TIE, new List<Chip>()},
            {KindOfBet.PLAYER_PAIR, new List<Chip>()},
            {KindOfBet.BANKER_PAIR, new List<Chip>()},
        };
        ShowTotalAmountBet();
    }

    public void DestroyDroppedChips()
    {
        foreach (var chipsList in droppedChips.Values)
        {
            foreach (var chip in chipsList)
            {
                Destroy(chip.gameObject);
            }
        }

        ResetDroppedChips();
    }

    private void ProcessChips(bool blocksRaycasts)
    {
        foreach (var element in droppedChips)
        {
            foreach (var chip in element.Value)
            {
                chip.GetComponent<CanvasGroup>().blocksRaycasts = blocksRaycasts;
            }
        }
    }

    private void ShowTotalAmountBet()
    {
       totalAmountBetText.text = "TOTAL AMOUNT BET\n" + totalAmountBet; 
    }
}