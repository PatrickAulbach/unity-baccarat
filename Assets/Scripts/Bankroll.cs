using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bankroll : MonoBehaviour
{   
    public int bankroll {get; set;}
    private Dictionary<KindOfBet, int> betAmounts;
    private TextMeshProUGUI bankrollText;
    [SerializeField] MultipleDropHandler dropHandler;
 
    private void Awake() {
        bankrollText = GetComponent<TextMeshProUGUI>();
    }
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
            bankroll -= amount;
        }

        dropHandler.DestroyDroppedChips();
    }

    public int ComputeWinnings(KindOfBet kindOfBet)
    {
        var result = kindOfBet switch
        {
            var x when x.Equals(KindOfBet.PLAYER) || x.Equals(KindOfBet.BANKER) => betAmounts[kindOfBet] * 2,
            var x when x.Equals(KindOfBet.PLAYER_PAIR) || x.Equals(KindOfBet.BANKER_PAIR) => betAmounts[kindOfBet] * 12,
            KindOfBet.TIE => betAmounts[kindOfBet] * 9,
            _ => 0,
        };

        bankroll += result;
        return result;
    }

    public void ShowBankroll()
    {
        bankrollText.text = "BANKROLL\n" + bankroll;
    }
}
