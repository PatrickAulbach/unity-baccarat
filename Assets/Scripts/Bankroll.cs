using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bankroll : MonoBehaviour
{   
    public int bankroll {get; set;}
    private Dictionary<KindOfBet, int> betAmounts;
    [SerializeField] TextMeshProUGUI bankrollText;
    [SerializeField] MultipleDropHandler dropHandler;
 
    public int SetBets(Dictionary<KindOfBet, List<Chip>> bets)
    {
        betAmounts = new Dictionary<KindOfBet, int>();
        var totalAmount = 0;

        foreach (var bet in bets)
        {
            int amount = 0;
            var chips = bet.Value;

            foreach (var chip in chips)
            {
                amount += chip.value;
            }
            betAmounts.Add(bet.Key, amount);
            totalAmount += amount;
            bankroll -= amount;
        }

        dropHandler.DestroyDroppedChips();

        return totalAmount;
    }

    public int ComputeWinnings(KindOfBet result)
    {
        var winnings = result switch
        {
            var x when x.Equals(KindOfBet.PLAYER) || x.Equals(KindOfBet.BANKER) => betAmounts[result] * 2,
            var x when x.Equals(KindOfBet.PLAYER_PAIR) || x.Equals(KindOfBet.BANKER_PAIR) => betAmounts[result] * 12,
            KindOfBet.TIE => betAmounts[result] * 9,
            _ => 0,
        };

        bankroll += winnings;
        return winnings;
    }

    public void ShowBankroll()
    {
        bankrollText.text = "BANKROLL\n" + bankroll;
    }
    
}
