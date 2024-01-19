
public class LocationConjuction
{
    public int p1Points { get; private set; }
    public int p2Points { get; private set; }

    public LocationTile p1Side;
    public LocationTile p2Side;

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
}
