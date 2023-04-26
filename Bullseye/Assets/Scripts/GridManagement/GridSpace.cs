using UnityEngine;

public class GridSpace : MonoBehaviour
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Card PlacedCard { get; private set; }
    public bool IsOccupied => PlacedCard != null;

    public void Initialize(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void PlaceCard(Card card)
    {
        PlacedCard = card;
        // Update grid space visuals to display the card**********need modify
    }

    public void FlipCard()
    {
        if (PlacedCard != null && !PlacedCard.IsFaceUp)
        {
            PlacedCard.Flip();
            // Update grid space visuals to display the flipped card**********need modify
        }
    }
}