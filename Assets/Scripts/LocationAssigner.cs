using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationAssigner : Singleton<LocationAssigner>
{
    [SerializeField] private List<LocationBase> locations = new List<LocationBase>();

    public LocationBase GetRandomLocation()
    {
        if (locations == null || locations.Count == 0)
        {
            return null;
        }
        int randomIndex = UnityEngine.Random.Range(0, locations.Count);
        return locations[randomIndex];
    }
}
