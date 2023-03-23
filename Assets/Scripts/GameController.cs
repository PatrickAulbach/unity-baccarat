using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] BaccaratRules rulesEngine;
    [SerializeField] Deck deck;
    [SerializeField] CardCreator cardCreator;
    [SerializeField] Bankroll bankroll;
    [SerializeField] Button dealButton;
    [SerializeField] List<DropZone> dropZones;
    [SerializeField] MultipleDropHandler dropHandler;
    private Dictionary<string, int> scores;
    private List<SpriteValue> playerHand;
    private List<SpriteValue> bankerHand;
    private List<Card> cardsToDestroy;
    private Dictionary<KindOfBet, List<Chip>> bets;
    private GameState gameState;
    private ChipManager chipManager;
    
    
    void Start()
    {
        dealButton.onClick.AddListener(StartGame);
        gameState = GameState.NOT_RUNNING;
        cardsToDestroy = new List<Card>();
        chipManager = GetComponent<ChipManager>();
        bankroll.bankroll = 1000;
        bankroll.ShowBankroll();
    }

    void StartGame() 
    {   
        var totalAmount = bankroll.SetBets(dropHandler.droppedChips);
        
        if (GameState.RUNNING.Equals(gameState) || totalAmount == 0)
        {
            return;
        }

        InitGame();

        for (int i = 0; i < 2; i++)
        {
            playerHand.Add(deck.DrawCard());
        }
        for (int i = 0; i < 2; i++)
        {
            bankerHand.Add(deck.DrawCard());
        }

        ComputeResult();
    
        var result = checkForNatural();

        if (KindOfBet.NONE.Equals(result)) 
        {
            DrawAdditionalCards();
            result = ComputeWinner();
        }

        StartCoroutine(ShowSprites());
        var winningAmount = bankroll.ComputeWinnings(result);

        if (playerHand[0].type.Equals(playerHand[1].type))
        {
            winningAmount += bankroll.ComputeWinnings(KindOfBet.PLAYER_PAIR);
        }
        if (bankerHand[0].type.Equals(bankerHand[1].type))
        {
            winningAmount += bankroll.ComputeWinnings(KindOfBet.BANKER_PAIR);
        }

        chipManager.SpawnChips(winningAmount);
        bankroll.ShowBankroll();

    }

    private KindOfBet checkForNatural()
    {
        if (scores["Player"] == scores["Dealer"])
        {
            return KindOfBet.TIE;
        }
        
        if (rulesEngine.IsNatural(scores["Player"], scores["Dealer"]))
        {
            return scores["Player"] < scores["Dealer"] ? KindOfBet.BANKER : KindOfBet.PLAYER;
        }
        
        return KindOfBet.NONE;
    }

    private void DrawAdditionalCards() 
    {
        if (rulesEngine.CheckEntityDraw(scores["Player"])) 
        {
            playerHand.Add(deck.DrawCard());
            
            if (rulesEngine.CheckBankerDraw(scores["Dealer"], (int) playerHand[2].value)) {
                bankerHand.Add(deck.DrawCard());
            }
        } 
        else if (rulesEngine.CheckEntityDraw(scores["Dealer"])) 
        {
            bankerHand.Add(deck.DrawCard());
            
        }
    }
    private KindOfBet ComputeWinner() 
    {
        ComputeResult();
        if (scores["Player"] == scores["Dealer"]) return KindOfBet.TIE;
        
        return scores["Player"] < scores["Dealer"] ? KindOfBet.BANKER : KindOfBet.PLAYER;
    }

    private void ComputeResult() 
    {
        scores["Player"] = playerHand.Sum(card => (int)card.value) % 10;
        scores["Dealer"] = bankerHand.Sum(card => (int)card.value) % 10;
    }

    IEnumerator ShowSprites()
    {
        for (int i = 0; i < 2; i++)
        {
            var card = cardCreator.SpawnCard();
            cardsToDestroy.Add(card);
            card.spriteValue = playerHand[i];
            card.SetSprite();
            card.Move(BaccaratConstants.PLAYER_CARD_POSITIONS[i]);
            yield return new WaitForSeconds(OptionValues.gameSpeed / 3);
        }

        for (int i = 0; i < 2; i++)
        {
            var card = cardCreator.SpawnCard();
            cardsToDestroy.Add(card);
            card.spriteValue = bankerHand[i];
            card.SetSprite();
            card.Move(BaccaratConstants.BANKER_CARD_POSTIONS[i]);
            yield return new WaitForSeconds(OptionValues.gameSpeed / 3);
        }

        if (playerHand.Count > 2)
        {
            Card card = cardCreator.SpawnCard();
            cardsToDestroy.Add(card);
            card.spriteValue = playerHand[2];
            card.SetSprite();
            card.Move(BaccaratConstants.PLAYER_CARD_POSITIONS[2]);
            card.Rotate();
            yield return new WaitForSeconds(OptionValues.gameSpeed / 3);
        }

        if (bankerHand.Count > 2)
        {
            Card card = cardCreator.SpawnCard();
            cardsToDestroy.Add(card);
            card.spriteValue = bankerHand[2];
            card.SetSprite();
            card.Move(BaccaratConstants.BANKER_CARD_POSTIONS[2]);
            card.Rotate();
            yield return new WaitForSeconds(OptionValues.gameSpeed / 3);
        }
        
        gameState = GameState.NOT_RUNNING;
    }

    private void InitGame()
    {
        foreach (var card in cardsToDestroy)
        {
            card.Reset();
        }
        cardsToDestroy = new List<Card>();

        playerHand = new List<SpriteValue>();
        bankerHand = new List<SpriteValue>();
        scores = new Dictionary<string, int>();
        gameState = GameState.RUNNING;
    }

}
