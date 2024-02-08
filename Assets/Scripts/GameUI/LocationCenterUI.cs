using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace GameUI
{
    public class LocationCenterUI : MonoBehaviour
    {
        [SerializeField] private Image centerImage;
        [SerializeField] private TextMeshProUGUI centerTitle;
        [SerializeField] private TextMeshProUGUI centerDescription;
        [SerializeField] private Color winningColor;
        [SerializeField] private Color losingColor;
        [SerializeField] private Image p1Hexagon;
        [SerializeField] private Image p2Hexagon;
        [SerializeField] private TextMeshProUGUI p1PointsTMP;
        [SerializeField] private TextMeshProUGUI p2PointsTMP;

        public void UpdateCenter(
            LocationBase location, 
            int p1points, 
            int p2points, 
            int winnerId)
        {
            centerImage.sprite = location?.sprite;
            centerTitle.text = location?.name;
            centerTitle.outlineWidth = .5f;
            centerDescription.outlineWidth = .3f;
            centerDescription.text = location?.description;
            p1PointsTMP.text = p1points.ToString();
            p2PointsTMP.text = p2points.ToString();

            p1Hexagon.color = losingColor;
            p2Hexagon.color = losingColor;
            if (winnerId == GameManager.Player1Id)
            {
                p1Hexagon.color = winningColor;
            }
            else if(winnerId == GameManager.Player2Id)
            {
                p2Hexagon.color = winningColor;
            }
        }
    }
}