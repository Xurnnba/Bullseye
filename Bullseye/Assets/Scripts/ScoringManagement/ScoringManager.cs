using System.Collections.Generic;
using UnityEngine;

public class ScoringManager : MonoBehaviour
{
    //public List<Sequence> DetectSequencesOnGrid()
    //{
    //    // Implement sequence detection logic on the grid
    //}
    public static ScoringManager Instance;

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

    public void ApplyPenalties(Player player)
    {
        int penalty = 0;
        foreach (Card card in player.Hand)
        {
            penalty += card.CardValue;
        }
        player.AddToScore(-penalty);
    }

    public List<Sequence> DetectSequencesOnGrid()
    {
        List<Sequence> sequences = new List<Sequence>();

        // Check rows, columns, and diagonals for sequences of the same color
        // Add detected sequences to the "sequences" list

        return sequences;
    }


}


