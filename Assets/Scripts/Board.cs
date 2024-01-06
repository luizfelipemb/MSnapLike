using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Board
{
    public LocationTile[] p1Side = new LocationTile[3];
    public LocationTile[] p2Side = new LocationTile[3];

    public bool CheckIfLocationIsAvailable(int player, int locationId)
    {
        if(player == 0)
        {
            return p1Side[locationId].HasSpace();
        }
        return p2Side[locationId].HasSpace();
    }
}
