using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//idea for future: each player with its own board inside its script
//                   + a script with events happening with each board so
//                     they can communicate.

[System.Serializable]
public class Board
{
    public LocationTile[] p1Side = new LocationTile[3];
    public LocationTile[] p2Side = new LocationTile[3];

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
}
