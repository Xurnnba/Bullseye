using UnityEngine;

public class Card
{
    public Color CardColor { get; private set; }
    public int CardValue { get; private set; }
    public bool IsFaceUp { get; private set; }

    public Card(Color cardColor, int cardValue)
    {
        CardColor = cardColor;
        CardValue = cardValue;
        IsFaceUp = false;
    }

    public void Flip()
    {
        IsFaceUp = !IsFaceUp;
    }
}