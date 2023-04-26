using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int gridWidth = 3;
    public int gridHeight = 3;
    public int numberOfRounds = 3;
    public int startingActionPoints = 5;
    public int startingHandSize = 4;
    public int[] cardValues = { 1, 2, 3, 4, 5 };
    public Color[] cardColors = { Color.red, Color.blue, Color.black, Color.yellow };

    private int currentRound = 1;

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

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        // Initialize grid, players, card deck, UI, etc.
    }

    public void StartNextRound()
    {
        currentRound++;

        if (currentRound <= numberOfRounds)
        {
            // Reset grid, action points, and draw new cards for the next round
        }
        else
        {
            // End game and display the winner
        }
    }
}