using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bankroll : MonoBehaviour
{   
    public int bankroll {get; private set;}
    public int betAmount {get; private set;}
    private Dictionary<KindOfBet, int> betAmounts;
    [SerializeField] MultipleDropHandler dropHandler;
 
    public void SetBets(Dictionary<KindOfBet, List<Chip>> bets)
    {
        betAmounts = new Dictionary<KindOfBet, int>();

        foreach (var bet in bets)
        {
            int amount = 0;
            var chips = bet.Value;

            foreach (var chip in chips)
            {
                amount += chip.value;
            }
            betAmounts.Add(bet.Key, amount);
        }

        dropHandler.DestroyDroppedChips();
    }

    public int ComputeWinnings(KindOfBet kindOfBet)
    {
        return kindOfBet switch
        {
            var x when x.Equals(KindOfBet.PLAYER) || x.Equals(KindOfBet.BANKER) => betAmounts[kindOfBet],
            var x when x.Equals(KindOfBet.PLAYER_PAIR) || x.Equals(KindOfBet.BANKER_PAIR) => betAmounts[kindOfBet] * 11,
            KindOfBet.TIE => betAmounts[kindOfBet] * 8,
            _ => 0,
        };
    }
}
