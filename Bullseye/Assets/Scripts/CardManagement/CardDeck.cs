using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    private List<Card> deck;

    private void Awake()
    {
        CreateDeck();
    }

    private void CreateDeck()
    {
        deck = new List<Card>();
        foreach (Color color in GameManager.Instance.cardColors)
        {
            foreach (int value in GameManager.Instance.cardValues)
            {
                Card card = new Card(color, value);
                deck.Add(card);
            }
        }
        ShuffleDeck();
    }

    private void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int randomIndex = Random.Range(0, deck.Count);
            Card tempCard = deck[i];
            deck[i] = deck[randomIndex];
            deck[randomIndex] = tempCard;
        }
    }

    public Card DrawCard()
    {
        if (deck.Count > 0)
        {
            Card drawnCard = deck[0];
            deck.RemoveAt(0);
            return drawnCard;
        }
        return null;
    }
}
