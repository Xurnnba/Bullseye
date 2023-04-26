using System;
using Unity;
using UnityEngine;
using System.Collections.Generic;
public class Sequence:MonoBehaviour
{
    public static Sequence Instance;

    public List<Card> cards;
    public Color color;
    public Player player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int Score
    {
        get
        {
            return Score;
        }
        private set
        {
            Score = Instance.GetTotalValue();
        }
    }

    

    public Sequence(List<Card> cards, Color color, Player player)
    {
        this.cards = cards;
        this.color = color;
        this.player = player;
    }

    private int GetTotalValue()
    {
        int totalValue = 0;

        foreach (Card card in cards)
        {
            totalValue += card.CardValue;
        }

        return totalValue;
    }


}
