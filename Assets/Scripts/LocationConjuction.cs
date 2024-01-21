
public class LocationConjuction
{
    public int p1Points { get; private set; }
    public int p2Points { get; private set; }

    public LocationTile p1Side;
    public LocationTile p2Side;
    public int winnerId { get; private set; } = GameManager.NullId;

    public LocationConjuction()
    {
        p1Side = new LocationTile();
        p2Side = new LocationTile();
    }

    public void UpdatePoints()
    {
        p1Points = p1Side.GetPoints();
        p2Points = p2Side.GetPoints();
    }
    public int CalculateWinner()
    {
        if (p1Points > p2Points)
            winnerId = GameManager.Player1Id;
        else if (p2Points > p1Points)
            winnerId = GameManager.Player2Id;
        else
            winnerId = GameManager.NullId;
        return winnerId;
    }
    public int P1PointsMinusP2Points()
    {
        return p1Points - p2Points;
    }
}
