using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

//idea for future: each player with its own board inside its script
//                   + a script with events happening with each board so
//                     they can communicate.

[System.Serializable]
public class Board
{
    private LocationTile[] p1Side = new LocationTile[3];
    private LocationTile[] p2Side = new LocationTile[3];
    public Board()
    {
        for (int i = 0; i < 3; i++)
        {
            p1Side[i] = new LocationTile();
            p2Side[i] = new LocationTile();
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
    public LocationTile GetLocationTile(int locationId)
    {
        int playerId = Utils.GetLocationOwner(locationId);
        if (playerId == GameManager.Player1Id)
        {
            return p1Side[locationId];
        }
        return p2Side[locationId - 3];
    }
}
