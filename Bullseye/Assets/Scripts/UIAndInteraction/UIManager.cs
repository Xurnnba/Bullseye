using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text[] playerScores;
    public Text currentPlayerText;
    public GameObject endGamePanel;
    public Text winnerText;


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

    public void UpdatePlayerScores(Player[] players)
    {
        for (int i = 0; i < players.Length; i++)
        {
            playerScores[i].text = $"Player {players[i].PlayerID}: {players[i].TotalScore}";
        }
    }

    public void UpdateCurrentPlayerText(Player currentPlayer)
    {
        currentPlayerText.text = $"Player {currentPlayer.PlayerID}'s Turn";
    }

    public void ShowEndGamePanel(Player winner)
    {
        endGamePanel.SetActive(true);
        winnerText.text = $"Player {winner.PlayerID} Wins!";
    }

    public void HideEndGamePanel()
    {
        endGamePanel.SetActive(false);
    }
}


