using System.Collections;
using System.Collections.Generic;

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
    public bool CheckIfLocationIsAvailable(int playerId, int locationId)
    {
        if(playerId == 0)
        {
            return p1Side[locationId].HasSpace();
        }
        return p2Side[locationId].HasSpace();
    }
    public void PlaceCardInLocation(int playerId, CardInGame card, int locationId)
    {
        if (playerId == 0)
        {
            p1Side[locationId].PlaceCard(card);
        }
        else
        {
            p2Side[locationId].PlaceCard(card); 
        }
    }
    public LocationTile GetLocationTile(int locationId)
    {
        if (locationId <= 2)
        {
            return p1Side[locationId];
        }
        return p2Side[locationId-3];
    }
}
