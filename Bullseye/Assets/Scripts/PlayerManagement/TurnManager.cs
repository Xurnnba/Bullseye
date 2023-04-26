using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Player[] players;
    private int currentPlayerIndex;

    private void Start()
    {
        currentPlayerIndex = 0;
    }

    public Player GetCurrentPlayer()
    {
        return players[currentPlayerIndex];
    }

    public void EndTurn()
    {
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
        // Check for the end of the round
    }

    public void PerformActionPlaceCard(Player player, Card card, int x, int y)
    {
        if (player.ActionPoints > 0 && GridManager.Instance.PlaceCardOnGridSpace(card, x, y))
        {
            player.UseActionPoint();
            player.RemoveCardFromHand(card);
            EndTurn();
        }
    }

    public void PerformActionFlipCard(Player player, int x, int y)
    {
        if (player.ActionPoints > 0)
        {
            GridSpace gridSpace = GridManager.Instance.GetGridSpace(x, y);
            if (gridSpace != null && !gridSpace.IsOccupied)
            {
                gridSpace.FlipCard();
                player.UseActionPoint();
                EndTurn();
            }
        }
    }

    public void PerformActionClaimSequence(Player player, Sequence sequence)
    {
        if (player.ActionPoints > 0 && sequence != null)
        {
            player.UseActionPoint();
            player.AddToScore(sequence.Score);
            GridManager.Instance.RemoveSequenceFromGrid(sequence);//********* need modify
            EndTurn();
        }
    }

    
    private bool CheckEndOfRound()
    {
        // Check if all grid spaces are filled or all players have used their action points
        if (GridManager.Instance.AllGridSpacesFilled() || AllPlayersOutOfActionPoints())//************ need modify
        {
            return true;
        }
        return false;
    }

    private bool AllPlayersOutOfActionPoints()
    {
        foreach (Player player in players)
        {
            if (player.ActionPoints > 0)
            {
                return false;
            }
        }
        return true;
    }

    private void EndRound()
    {
        // Calculate scores, apply penalties, and update UI
        foreach (Player player in players)
        {
            ScoringManager.Instance.ApplyPenalties(player);
        }
        UIManager.Instance.UpdatePlayerScores(players);

        // Check for end-of-game condition and handle it accordingly
        Player winner = CheckEndOfGame();
        if (winner != null)
        {
            UIManager.Instance.ShowEndGamePanel(winner);
            // Implement a reset or restart button to start a new game
        }
        else
        {
            // Reset the game state for the next round
            foreach (Player player in players)
            {
                player.ResetForNewRound();
            }
            GridManager.Instance.ClearGrid();//************* need implementation
            currentPlayerIndex = 0;
        }
    }

    private Player CheckEndOfGame()
    {
        // Implement end-of-game condition check
        // Return the winning player if the condition is met, otherwise return null
        return new Player();
        //******************* need modify
    }


}

