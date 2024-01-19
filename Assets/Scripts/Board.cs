
//idea for future: each player with its own board inside its script
//                   + a script with events happening with each board so
//                     they can communicate.

[System.Serializable]
public class Board
{
    public LocationConjuction[] locations { get; private set; } = new LocationConjuction[3];

    public Board()
    {
        for (int i = 0; i < 3; i++)
        {
            locations[i] = new LocationConjuction();
        }
    }
    public bool CheckIfLocationIsAvailable(int locationId)
    {
        return GetLocationTile(locationId).HasSpace();
    }
    public void PlaceCardInLocation(CardInGame card, int locationId)
    {
        GetLocationTile(locationId).PlaceCard(card);
    }
    public void UpdateLocationsPoints()
    {
        foreach (LocationConjuction location in locations)
        {
            location.UpdatePoints();
        }
    }
    public LocationTile GetLocationTile(int locationId)
    {
        int playerId = Utils.GetLocationOwner(locationId);
        if (playerId == GameManager.Player1Id)
        {
            return locations[locationId].p1Side;
        }
        return locations[locationId - 3].p2Side;
    }
}
