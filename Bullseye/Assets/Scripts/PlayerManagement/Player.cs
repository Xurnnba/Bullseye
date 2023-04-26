using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerID { get; private set; }
    public int ActionPoints { get; private set; }
    public int TotalScore { get; private set; }
    public List<Card> Hand { get; private set; }

    public void Initialize(int playerID)
    {
        PlayerID = playerID;
        ActionPoints = GameManager.Instance.startingActionPoints;
        Hand = new List<Card>();
        TotalScore = 0;
    }

    public void ResetForNewRound()
    {
        ActionPoints = GameManager.Instance.startingActionPoints;
    }

    public void AddCardToHand(Card card)
    {
        Hand.Add(card);
    }

    public void RemoveCardFromHand(Card card)
    {
        Hand.Remove(card);
    }

    public void UseActionPoint()
    {
        ActionPoints--;
    }

    public void AddToScore(int score)
    {
        TotalScore += score;
    }
}