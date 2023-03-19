using System;

using UnityEngine;

public class BaccaratRules : MonoBehaviour 
{
    public Boolean CheckEntityDraw(int score) {
        return score <= 5;
    }

    public Boolean IsNatural(int playerScore, int bankerScore) {
        return playerScore == 8 || playerScore == 9 || bankerScore == 8 || bankerScore == 9;
    }

    public Boolean CheckBankerDraw(int bankerScore, int playersThirdCard) {

        switch(bankerScore) 
        {
            case int x when (x <= 2):
                return true; 
            case 3:
                return playersThirdCard != 8;
            case 4:
                return playersThirdCard >= 2 && playersThirdCard <= 7;
            case 5:
                return playersThirdCard >= 4 && playersThirdCard <= 7;
            case 6:
                return playersThirdCard >= 6 && playersThirdCard <= 7;
            default:
                return false;
        };
    }
}