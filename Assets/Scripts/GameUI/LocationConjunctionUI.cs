using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI
{
    public class LocationConjunctionUI : MonoBehaviour
    {
        [SerializeField] private LocationCenterUI locationCenter;
        [SerializeField] private LocationUI locationP1;
        [SerializeField] private LocationUI locationP2;

        public void UpdateLocationConjunction(LocationConjuction thisLocation)
        {
            locationP1.UpdateLocation(thisLocation.p1Side);
            locationP2.UpdateLocation(thisLocation.p2Side);
            locationCenter.UpdateCenter(
                thisLocation.p1Points, 
                thisLocation.p2Points,
                thisLocation.winnerId
                );
            
        }
    }
}