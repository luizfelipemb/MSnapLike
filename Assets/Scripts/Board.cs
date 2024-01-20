
//idea for future: each player with its own board inside its script
//                   + a script with events happening with each board so
//                     they can communicate.

[System.Serializable]
public class Board
{
    public LocationConjuction[] locations { get; private set; } = new LocationConjuction[3];
    public int GameWinnerId { get; private set; } = GameManager.NullId;
    private (int winner0, int winner1, int winner2) winnerPerLocation;
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
            location.CalculateWinner();
        }
    }
    public int GetGameWinnerId()
    {
        return GameManager.NullId;
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
