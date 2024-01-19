using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace GameUI
{
    public class LocationCenterUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI p1Points;
        [SerializeField] private TextMeshProUGUI p2Points;

        public void UpdateCenter(int p1points, int p2points)
        {
            p1Points.text = p1points.ToString();
            p2Points.text = p2points.ToString();
        }
    }
}