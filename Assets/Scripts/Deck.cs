using System;
using System.Collections.Generic;
using UnityEngine;
public class Deck : MonoBehaviour
{

    [SerializeField] List<SpriteValue> cardValues;
    [SerializeField] List<SpriteValue> testValues;
    [SerializeField] bool isTest; 
    private List<SpriteValue> deck;
    void Start()
    {
        CreateDeck();
    }

    public SpriteValue DrawCard() 
    {
        if (!isTest)
        {
            if (deck.Count < 20)
            {
                CreateDeck();
            }
        }

        var drawnCard = deck[0];
        deck.RemoveAt(0);
        
        return drawnCard;

    }

    private void CreateDeck() 
    {
        if (!isTest)
        {
            deck = new List<SpriteValue>();

            for (int i = 0; i < 5; i++)
            {
                deck.AddRange(cardValues);
            }

            deck.Shuffle();
        }
        else
        {
            deck = new List<SpriteValue>();
            deck.AddRange(testValues);
        }
        
    }

}

[Serializable]
public class SpriteValue
{
    public Sprite sprite;
    public Value value;
    public Type type;
}

public static class Extensions
{
    private static System.Random rand = new System.Random();
 
    public static void Shuffle<T>(this IList<T> values)
    {
        for (int i = values.Count - 1; i > 0; i--) {
            int k = rand.Next(i + 1);
            T value = values[k];
            values[k] = values[i];
            values[i] = value;
        }
    }
}

