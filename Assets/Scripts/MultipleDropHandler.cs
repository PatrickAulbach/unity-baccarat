using System.Collections.Generic;
using UnityEngine;

public class MultipleDropHandler : MonoBehaviour {

    public Dictionary<KindOfBet, List<Chip>> droppedChips; 

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
        droppedChips[kindOfBet].Remove(chip);
    }

    private void ResetDroppedChips()
    {
        droppedChips = new Dictionary<KindOfBet, List<Chip>> {
            {KindOfBet.PLAYER, new List<Chip>()},
            {KindOfBet.BANKER, new List<Chip>()},
            {KindOfBet.TIE, new List<Chip>()},
            {KindOfBet.PLAYER_PAIR, new List<Chip>()},
            {KindOfBet.BANKER_PAIR, new List<Chip>()},
        };
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
}